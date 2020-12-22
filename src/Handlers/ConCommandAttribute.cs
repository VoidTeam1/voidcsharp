using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VoidSharp.Handlers
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ConCommandAttribute : Attribute
    {
        public string Name { get; }
        
        public ConCommandAttribute(string name)
        {
            Name = name;
        }
        
        /// <summary>
        /// Gets all methods which have a ConCommand attribute.
        /// </summary>
        /// <param name="type">The type (preferably Class) to check.</param>
        /// <returns>A list of MethodInfos.</returns>
        public static List<MethodInfo> GetAllConCommandAttributes(Type type)
        {
            var methods = type.GetMethods().ToList()
                .Where(x => x.GetCustomAttributes(typeof(ConCommandAttribute), false).Length > 0)
                .ToList();

            return methods;
        }
    }
}