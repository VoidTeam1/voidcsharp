using System;
using System.Reflection;
using VoidSharp;

namespace VoidSharp.ORM.Serializers
{
    public class StringSerializer : ISerializerBase
    {
        public string Serialize(object obj, IDatabaseDriver driver)
        {
            string str = driver.Escape((string) obj, true);
            
            return "'" + str + "'";
        }

        public object Deserialize(object obj)
        {
            return obj;
        }
    }
}