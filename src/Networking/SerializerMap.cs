using System;
using System.Collections.Generic;

namespace VoidSharp.Networking
{
    public static class SerializerMap
    {
        public static Dictionary<Type, INetworkSerializer> Serializers { get; set; } = new Dictionary<Type, INetworkSerializer>();
        
        public static void RegisterSerializer<TType, TSerializer>() where TSerializer : INetworkSerializer, new()
        {
            TSerializer t = new TSerializer();
            Serializers[typeof(TType)] = t;
        }
    }
}