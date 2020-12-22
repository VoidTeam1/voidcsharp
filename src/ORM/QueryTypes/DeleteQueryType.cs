using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VoidSharp.ORM.Attributes;
using VoidSharp.ORM.Specifiers;

namespace VoidSharp.ORM.QueryTypes
{
    public class DeleteQueryType<T> : QueryType where T : new()
    {
        private List<WhereSpecifier> WhereSpecifiers { get; set; }
        
        public DeleteQueryType(Database database) : base(database)
        {
            WhereSpecifiers = new List<WhereSpecifier>();
        }
        
        public DeleteQueryType<T> Where(string a, string comparator, object b)
        {
            var specifier = new WhereSpecifier(a, comparator, b);
            WhereSpecifiers.Add(specifier);

            return this;
        }
        
        public DeleteQueryType<T> Where(PropertyInfo type, string comparator, object b)
        {
            var propertyInfo = typeof(T).GetProperty(type.Name);
            if (propertyInfo == null) throw new Exception(type.Name + " is not a member of " + typeof(T).Name + "!");

            Where(type.Name, comparator, b);

            return this;
        }

        public override string GenerateQuery(Type type)
        {
            string tableName = TableAttribute.GetAttributeTable(type);
            
            StringBuilder stringBuilder = new StringBuilder($"DELETE FROM {tableName}");
            if (WhereSpecifiers.Count > 0)
            {
                stringBuilder.Append(" WHERE ");
                List<string> wheres = new List<string>();
                foreach (var specifier in WhereSpecifiers)
                {
                    PropertyInfo propertyInfo = type.GetProperty(specifier.Key);
                    if (propertyInfo == null) throw new Exception("Tried to select a non-existing column!");

                    if (!SerializerMap.Serializers.TryGetValue(propertyInfo.PropertyType, out var serializer))
                    {
                        throw new Exception("VoidORM can't serialize the type " + propertyInfo.PropertyType.Name + "!");
                    }
                    
                    string strValue = serializer.Serialize(specifier.Value, Database.DatabaseDriver);
                    wheres.Add("`" + specifier.Key + "` " + specifier.Comparator + " " + strValue);
                }

                stringBuilder.Append(string.Join(" AND ", wheres));
            }

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