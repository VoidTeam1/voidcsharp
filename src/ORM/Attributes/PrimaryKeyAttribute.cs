using System;
using System.Linq;
using System.Reflection;

namespace VoidSharp.ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class PrimaryKeyAttribute : Attribute
    {
        /// <summary>
        /// Does the property have a primary key attribute?
        /// </summary>
        /// <param name="classType">A property.</param>
        /// <returns></returns>
        public static bool IsPrimaryKey(PropertyInfo classType)
        {
            var attributes = classType.GetCustomAttributes(false).Where(x => x.GetType() == typeof(PrimaryKeyAttribute)).ToList();

            PrimaryKeyAttribute attribute = attributes.Count > 0 ? (PrimaryKeyAttribute) attributes[0] : null;
            return attribute != null;
        }
    }
}