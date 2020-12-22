using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VoidSharp.Handlers;

namespace VoidSharp.Networking
{
    // ReSharper disable once InconsistentNaming
    public class RPCAttribute : Attribute
    {
        /// <summary>
        /// Gets all methods which have a RPC attribute.
        /// </summary>
        /// <param name="type">The type (preferably Class) to check.</param>
        /// <returns>A list of MethodInfos.</returns>
        // ReSharper disable once InconsistentNaming
        public static List<MethodInfo> GetAllRPCAttributes(Type type)
        {
            var methods = type.GetMethods().ToList()
                .Where(x => x.GetCustomAttributes(typeof(RPCAttribute), false).Length > 0)
                .ToList();

            return methods;
        }
    }
}