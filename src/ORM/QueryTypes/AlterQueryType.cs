using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VoidSharp.ORM.Attributes;
using VoidSharp.ORM.Specifiers;

namespace VoidSharp.ORM.QueryTypes
{
    public class AlterQueryType<T> : QueryType where T : new()
    {
        private List<AlterSpecifier> AddColumns { get; set; }
        
        public AlterQueryType(Database database) : base(database)
        {
            AddColumns = new List<AlterSpecifier>();
        }

        public AlterQueryType<T> AddColumn(string name, string dataType)
        {
            var specifier = new AlterSpecifier(name, dataType);
            AddColumns.Add(specifier);

            return this;
        }

        public override string GenerateQuery(Type type)
        {
            string tableName = TableAttribute.GetAttributeTable(type);
            
            StringBuilder stringBuilder = new StringBuilder($"ALTER TABLE {tableName} ");
            List<string> columnStrings = new List<string>();

            foreach (var specifier in AddColumns)
            {
                columnStrings.Add($"ADD COLUMN `{specifier.Name}` {specifier.DataType}");
            }

            stringBuilder.Append(string.Join(", ", columnStrings) + ";");
            return stringBuilder.ToString();
        }
        
        public async Task Execute()
        {
            string query = GenerateQuery(typeof(T));
            await Database.Query<T>(query);
        }
    }
}