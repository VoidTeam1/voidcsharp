using System;
using System.Collections.Generic;
using System.Text;
using VoidSharp;
using VoidSharp.ORM.Attributes;

namespace VoidSharp.ORM.QueryTypes
{
    public class CreateQueryType : QueryType
    {
        public static Dictionary<string, string> CSharpTypesToSqlTypesDictionary = new Dictionary<string, string>()
        {
            {"Int32", "INTEGER NOT NULL"},
            {"String", "VARCHAR({0})"},
            {"Boolean", "BOOLEAN"},
            {"Nullable`1", "INTEGER"},
            {"DateTime", "INTEGER"},
            {"Color", "VARCHAR(25)"},
            {"Job", "VARCHAR(100)"},
            {"Player", "VARCHAR(50)"},
            {"Object", "TEXT"},
            {"AccessoryModelBlacklist", "TEXT"},
            {"AccessorySlots", "TEXT"},
            {"ItemPrices", "TEXT"}
        };

        public CreateQueryType(Database database) : base(database)
        {
            
        }

        public override string GenerateQuery(Type type)
        {
            string tableName = TableAttribute.GetAttributeTable(type);
            
            StringBuilder queryBuilder = new StringBuilder($"CREATE TABLE IF NOT EXISTS `{tableName}` (");
            
            List<string> tableFields = new List<string>();
            List<string> primaryKeys = new List<string>();
            
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                string propertyTypeName = property.PropertyType.Name;
                string propertyName = property.Name;

                string sqlType = null;

                try
                {
                    sqlType = CSharpTypesToSqlTypesDictionary[propertyTypeName];
                }
                catch (Exception)
                {
                    throw new NotSupportedException("The C# type " + propertyTypeName + " is not supported for C# to SQL conversion.");
                }

                string dataType = sqlType;

                int? columnLength = ColumnLengthAttribute.GetAttributeColumnLength(property);
                if (columnLength != null || propertyTypeName == "String")
                {
                    dataType = string.Format(dataType, columnLength ?? 50);
                }

                bool isAutoIncrement = AutoIncrementAttribute.IsAutoIncrement(property);
                if (isAutoIncrement)
                {
                    if (Database.DatabaseDriver is MySQLoo)
                    {
                        dataType += " AUTO_INCREMENT";
                    }
                }

                bool isPrimaryKey = PrimaryKeyAttribute.IsPrimaryKey(property);
                if (isPrimaryKey)
                {
                    // Check if is SQLite/MySQL
                    if (Database.DatabaseDriver is MySQLoo)
                    {
                        primaryKeys.Add(propertyName);
                    } else if (Database.DatabaseDriver is SQLite)
                    {
                        dataType += " PRIMARY KEY";
                    }
                }

                tableFields.Add($"{propertyName} {dataType}");
            }

            queryBuilder.Append(string.Join(", ", tableFields));
            if (primaryKeys.Count > 0)
            {
                queryBuilder.Append(", PRIMARY KEY (");
                queryBuilder.Append(string.Join(", ", primaryKeys));
                queryBuilder.Append(")");
            }

            queryBuilder.Append(");");
            
            return queryBuilder.ToString();
        }
    }
}