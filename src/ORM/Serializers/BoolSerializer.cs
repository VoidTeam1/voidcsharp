using VoidSharp;

namespace VoidSharp.ORM.Serializers
{
    public class BoolSerializer : ISerializerBase
    {
        public string Serialize(object obj, IDatabaseDriver databaseDriver = null)
        {
            bool boolean = (bool) obj;
            return boolean ? "TRUE" : "FALSE";
        }

        public object Deserialize(object obj)
        {
            string str = (string) obj;
            bool result = str == "TRUE" || str == "true" || str == "1";
            return result;
        }
    }
}