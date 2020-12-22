using System;
using System.Linq;
using System.Reflection;

namespace VoidSharp.ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class AutoIncrementAttribute : Attribute
    {
        /// <summary>
        /// Does the property have an autoincrement attribute?
        /// </summary>
        /// <param name="classType">A property.</param>
        /// <returns></returns>
        public static bool IsAutoIncrement(PropertyInfo classType)
        {
            var attributes = classType.GetCustomAttributes(false).Where(x => x.GetType() == typeof(AutoIncrementAttribute)).ToList();

            AutoIncrementAttribute attribute = attributes.Count > 0 ? (AutoIncrementAttribute) attributes[0] : null;
            return attribute != null;
        }
    }
}