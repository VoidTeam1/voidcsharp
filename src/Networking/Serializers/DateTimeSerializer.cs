using System;
using System.Globalization;

namespace VoidSharp.Networking.Serializers
{
    public class DateTimeSerializer : INetworkSerializer
    {
        public void Write(NetworkWriter writer, object val)
        {
            DateTime time = (DateTime) val;
            int totalSeconds = (int) time.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            writer.WriteUInt(totalSeconds, 32);
        }

        public object Read(NetworkReader reader)
        {
            int timestamp = (int) reader.ReadUInt(32);
            return new DateTime(1970, 1, 1).AddSeconds(timestamp);
        }
    }
}