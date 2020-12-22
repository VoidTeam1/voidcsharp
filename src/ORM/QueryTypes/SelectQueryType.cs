using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VoidSharp.ORM.Attributes;
using VoidSharp.ORM.Specifiers;

namespace VoidSharp.ORM.QueryTypes
{
    public class SelectQueryType<T> : QueryType where T : new()
    {
        private List<string> Selects { get; set; }
        public List<WhereSpecifier> WhereSpecifiers { get; set; }
        
        public SelectQueryType(Database database) : base(database)
        {
            WhereSpecifiers = new List<WhereSpecifier>();
            Selects = new List<string>();
        }
        
        public SelectQueryType<T> Select(string column)
        {
            Selects.Add(column);
            return this;
        }
        
        public SelectQueryType<T> Select(params string[] columns)
        {
            foreach (string column in columns)
            {
                Select(column);
            }

            return this;
        }
        
        public SelectQueryType<T> Where(string a, string comparator, object b)
        {
            var specifier = new WhereSpecifier(a, comparator, b);
            WhereSpecifiers.Add(specifier);

            return this;
        }

        public SelectQueryType<T> Where(Func<T, object> type, string comparator, object b)
        {
            object obj = type(new T());
            Console.WriteLine(obj);
            var objType = obj.GetType();
            
            Console.WriteLine(objType);
            
            var propertyInfo = typeof(T).GetProperty(objType.Name);
            if (propertyInfo == null) throw new Exception(objType.Name + " is not a member of " + typeof(T).Name + "!");

            Where(objType.Name, comparator, b);

            return this;
        }

        public override string GenerateQuery(Type type)
        {
            string tableName = TableAttribute.GetAttributeTable(type);
            
            StringBuilder stringBuilder = new StringBuilder("SELECT");
            if (Selects.Count > 0)
            {
                stringBuilder.Append(" ");
                stringBuilder.Append(string.Join(", ", Selects));
            }
            else
            {
                stringBuilder.Append(" *");
            }
            stringBuilder.Append(" FROM ");
            stringBuilder.Append(tableName);

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
        
        public async Task<T> First()
        {
            string query = GenerateQuery(typeof(T));
            DatabaseResult<T> dbResult = await Database.Query<T>(query);
            List<T> list = dbResult.ToList();
            return list.Count > 0 ? list[0] : default;
        }
        public Task<T> Single => First();

        public async Task<List<T>> ToList()
        {
            string query = GenerateQuery(typeof(T));
            DatabaseResult<T> dbResult = await Database.Query<T>(query);
            return dbResult.ToList();
        }
    }
}