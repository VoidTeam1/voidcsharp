using System;
using System.Globalization;
using VoidSharp;

namespace VoidSharp.ORM.Serializers
{
    public class DateTimeSerializer : ISerializerBase
    {
        public string Serialize(object obj, IDatabaseDriver driver)
        {
            DateTime time = (DateTime) obj;
            return time.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString(CultureInfo.InvariantCulture);
        }

        public object Deserialize(object obj)
        {
            int timestamp = SerializerMap.ConvertToInt(obj);
            return new DateTime(1970, 1, 1).AddSeconds(timestamp);
        }
    }
}