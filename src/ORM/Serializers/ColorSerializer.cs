using System;
using System.Collections.Generic;
using System.Linq;
using VoidSharp;

namespace VoidSharp.ORM.Serializers
{
    public class ColorSerializer : ISerializerBase
    {
        public string Serialize(object obj, IDatabaseDriver driver)
        {
            Color color = (Color) obj;
            return $"'{color.R},{color.G},{color.B},{color.A}'";
        }

        public object Deserialize(object obj)
        {
            string str = obj.ToString();
            List<string> strs = str.Split(",").ToList();
            List<int> ints = strs.Select(int.Parse).ToList();

            return new Color(ints[0], ints[1], ints[2], ints[3]);
        }
    }
}