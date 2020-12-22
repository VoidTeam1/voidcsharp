using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VoidSharp;

namespace VoidSharp.Handlers
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class HookAttribute : Attribute
    {
        public string HookName { get; }
        public string HookId { get; }

        public HookAttribute(string hookName, string hookId = null)
        {
            HookName = hookName;
            HookId = hookId;
        }

        /// <summary>
        /// Gets all methods which have a Hook attribute.
        /// </summary>
        /// <param name="type">The type (preferably Class) to check.</param>
        /// <returns>A list of MethodInfos.</returns>
        public static List<MethodInfo> GetAllHookAttributes(Type type)
        {
            var methods = type.GetMethods().ToList()
                .Where(x => x.GetCustomAttributes(typeof(HookAttribute), false).Length > 0)
                .ToList();

            return methods;
        }
    }
}