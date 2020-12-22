using System;

namespace VoidSharp.Networking.Serializers
{
    public class IntegerSerializer : INetworkSerializer
    {
        public void Write(NetworkWriter writer, object val)
        {
            writer.WriteInt((int)val, 32);
        }

        public object Read(NetworkReader reader)
        {
            return (int) reader.ReadInt(32);
        }
    }
}