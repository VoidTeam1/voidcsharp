using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VoidSharp.ORM.Attributes;
using VoidSharp.ORM.Specifiers;

namespace VoidSharp.ORM.QueryTypes
{
    public class UpdateQueryType<T> : QueryType where T : new()
    {
        public List<InsertSpecifier> InsertSpecifiers { get; set; }
        
        public UpdateQueryType(Database database) : base(database)
        {
            InsertSpecifiers = new List<InsertSpecifier>();
        }
        
        public UpdateQueryType<T> Update(string column, object value)
        {
            var specifier = new InsertSpecifier(column, value);
            InsertSpecifiers.Add(specifier);

            return this;
        }
        
        public UpdateQueryType<T> Update(object obj)
        {
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                string propertyName = property.Name;
                object value = property.GetValue(obj);
                
                Update(propertyName, value);
            }

            return this;
        }

        public override string GenerateQuery(Type type)
        {
            string tableName = TableAttribute.GetAttributeTable(type);
            StringBuilder stringBuilder = new StringBuilder($"UPDATE {tableName} SET ");
            
            List<string> updateStatements = new List<string>();
            List<string> primaryKeys = new List<string>();
            
            foreach (var specifier in InsertSpecifiers)
            {
                PropertyInfo propertyInfo = type.GetProperty(specifier.Key);
                if (propertyInfo == null) throw new Exception("Tried to select a non-existing column!");

                if (!SerializerMap.Serializers.TryGetValue(propertyInfo.PropertyType, out var serializer))
                {
                    throw new Exception("VoidORM can't serialize the type " + propertyInfo.PropertyType.Name + "!");
                }
                
                string strValue = serializer.Serialize(specifier.Value, Database.DatabaseDriver);

                bool isPrimaryKey = PrimaryKeyAttribute.IsPrimaryKey(propertyInfo);
                if (isPrimaryKey)
                {
                    primaryKeys.Add("`" + specifier.Key + "` = " + strValue);
                }
                else
                {
                    updateStatements.Add("`" + specifier.Key + "` = " + strValue);
                }
            }
            
            stringBuilder.Append(string.Join(", ", updateStatements));
            stringBuilder.Append(" WHERE " + string.Join(" AND ", primaryKeys));
            stringBuilder.Append(";");

            return stringBuilder.ToString();
        }
        
        public async Task Execute()
        {
            string query = GenerateQuery(typeof(T));
            await Database.Query<T>(query);
        }
    }
}