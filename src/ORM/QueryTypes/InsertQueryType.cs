using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VoidSharp.ORM.Attributes;
using VoidSharp.ORM.Specifiers;

namespace VoidSharp.ORM.QueryTypes
{
    public class InsertQueryType<T> : QueryType where T : new()
    {
        private bool ShouldReplace { get; set; }
        public List<InsertSpecifier> InsertSpecifiers { get; set; }
        
        public InsertQueryType(Database database) : base(database)
        {
            InsertSpecifiers = new List<InsertSpecifier>();
        }
        
        public InsertQueryType<T> Insert(string column, object value)
        {
            var specifier = new InsertSpecifier(column, value);
            InsertSpecifiers.Add(specifier);

            return this;
        }
        
        public InsertQueryType<T> Replace(object obj)
        {
            return Insert(obj, true);
        }
        
        public InsertQueryType<T> Insert(object obj, bool replace = false)
        {
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                string propertyName = property.Name;

                object value = property.GetValue(obj);
                bool isAutoincrement = AutoIncrementAttribute.IsAutoIncrement(property);
                
                if (value != null && !isAutoincrement)
                    Insert(propertyName, value);
            }

            if (replace)
            {
                ShouldReplace = true;
            }

            return this;
        }

        public override string GenerateQuery(Type type)
        {
            string tableName = TableAttribute.GetAttributeTable(type);
            string insertType = ShouldReplace ? "REPLACE" : "INSERT";
            StringBuilder stringBuilder = new StringBuilder($"{insertType} INTO {tableName} (");
            
            List<string> columnNames = new List<string>();
            List<string> values = new List<string>();

            foreach (var specifier in InsertSpecifiers)
            {
                PropertyInfo propertyInfo = type.GetProperty(specifier.Key);
                if (propertyInfo == null) throw new Exception("Tried to select a non-existing column!");
                
                columnNames.Add("`" + specifier.Key + "`");

                if (!SerializerMap.Serializers.TryGetValue(propertyInfo.PropertyType, out var serializer))
                {
                    throw new Exception("VoidORM can't serialize the type " + propertyInfo.PropertyType.Name + "!");
                }

                string strValue = serializer.Serialize(specifier.Value, Database.DatabaseDriver);
                values.Add(strValue);
            }

            stringBuilder.Append(string.Join(", ", columnNames));
            stringBuilder.Append(")");

            stringBuilder.Append(" VALUES (");
            stringBuilder.Append(string.Join(", ", values));
            stringBuilder.Append(");");
            
            return stringBuilder.ToString();
        }

        public async Task Execute()
        {
            string query = GenerateQuery(typeof(T));
            await Database.Query<T>(query);
        }
    }
}