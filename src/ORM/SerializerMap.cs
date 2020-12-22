using System;
using System.Collections.Generic;

namespace VoidSharp.ORM
{
    public static class SerializerMap
    {
        public static Dictionary<Type, ISerializerBase> Serializers { get; set; } = new Dictionary<Type, ISerializerBase>();
        
        public static void RegisterSerializer<TType, TSerializer>() where TSerializer : ISerializerBase, new()
        {
            TSerializer t = new TSerializer();
            Serializers[typeof(TType)] = t;
        }

        public static int ConvertToInt(object val)
        {
            /*
            [[
                val = tonumber(val)
            ]]
            */
            return (int) val;
        }
    }
}