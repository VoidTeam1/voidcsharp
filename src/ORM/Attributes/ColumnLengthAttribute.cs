using System;
using System.Linq;
using System.Reflection;

namespace VoidSharp.ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class ColumnLengthAttribute : Attribute
    {
        private readonly int _columnLength;

        public ColumnLengthAttribute(int columnLength)
        {
            _columnLength = columnLength;
        }
        
        /// <summary>
        /// Gets the length of the column attribute.
        /// </summary>
        /// <param name="classType">A property.</param>
        /// <returns>A nullable int (null if does not have attribute)</returns>
        public static int? GetAttributeColumnLength(PropertyInfo classType)
        {
            var attributes = classType.GetCustomAttributes(false).Where(x => x.GetType() == typeof(ColumnLengthAttribute)).ToList();

            ColumnLengthAttribute attribute = attributes.Count > 0 ? (ColumnLengthAttribute) attributes[0] : null;
            return attribute?._columnLength;
        }
    }
}