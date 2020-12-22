using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VoidSharp.ORM
{
    public class ObjectMapper
    {
        public object Object { get; set; }

        public ObjectMapper(object o)
        {
            Object = o;
        }

        public Dictionary<string, Type> GetPropertyTypes()
        {
            var properties = Object.GetType().GetProperties();
            return properties.Select(x => new {String = x.Name, Property = x.PropertyType})
                .ToDictionary(x => x.String, v => v.Property);
        }

        private object MapValue(PropertyInfo property, object value)
        {
            ISerializerBase serializer = SerializerMap.Serializers[property.PropertyType];
            return serializer.Deserialize(value);
        }

        public void AssignValues(Dictionary<string, object> values)
        {
            var properties = Object.GetType().GetProperties();
            foreach (KeyValuePair<string, object> pair in values)
            {
                var property = properties.FirstOrDefault(x => x.Name == pair.Key);
                if (property == null) throw new Exception("Object does not contain property with name " + pair.Key + "!");
                
                object value = MapValue(property, pair.Value);
                /*
                [[
                this.Object[pair.Key] = value
                ]] 
                */
            }
        }
    }
}