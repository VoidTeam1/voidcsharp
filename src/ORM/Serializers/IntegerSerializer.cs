using System.Reflection;
using VoidSharp;

namespace VoidSharp.ORM.Serializers
{
    public class IntegerSerializer : ISerializerBase
    {
        public string Serialize(object obj, IDatabaseDriver driver)
        {
            return obj.ToString();
        }

        public object Deserialize(object obj)
        {
            return SerializerMap.ConvertToInt(obj);
        }
        
    }
}