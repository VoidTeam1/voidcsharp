using VoidSharp;

namespace VoidSharp.ORM.Serializers
{
    public class DynamicSerializer : ISerializerBase
    {
        public string Serialize(object obj, IDatabaseDriver databaseDriver)
        {
            string str = JSON.Serialize(obj);
            string escaped = databaseDriver.Escape(str, true);
            return escaped;
        }

        public object Deserialize(object obj)
        {
            return JSON.Parse((string) obj);
        }
    }
}