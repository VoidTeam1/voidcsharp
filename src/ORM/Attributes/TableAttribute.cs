using System;

namespace VoidSharp.ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class TableAttribute : Attribute
    {
        private readonly string _tableName;

        public TableAttribute(string tableName)
        {
            _tableName = tableName;
        }

        /// <summary>
        /// Gets the table name of the table attribute.
        /// </summary>
        /// <param name="classType">A property.</param>
        /// <returns>The name of the table (if null, then <c>"voidaccessories_" + classType.Name.ToLower()</c>)</returns>
        public static string GetAttributeTable(Type classType)
        {
            string tableName;
            var attributes = Attribute.GetCustomAttributes(classType, typeof(TableAttribute));

            TableAttribute attribute = attributes.Length > 0 ? (TableAttribute) attributes[0] : null;
            
            if (attribute == null)
            {
                tableName = "voidaccessories_" + classType.Name.ToLower();
            }
            else
            {
                tableName = attribute._tableName;
            }
            
            return tableName;
        }
    }
}