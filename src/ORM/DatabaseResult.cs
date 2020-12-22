using System;
using System.Collections.Generic;

namespace VoidSharp.ORM
{
    public class DatabaseResult<T> where T : new()
    {
        public object Result { get; set; }
        
        public DatabaseResult(object result)
        {
            Result = result;
        }

        public List<T> ToList()
        {
            List<T> list = new List<T>();
            List<Dictionary<string, object>> dict = (List<Dictionary<string, object>>) Result;
            foreach (var res in dict)
            {
                T t = new T();
                ObjectMapper objectMapper = new ObjectMapper(t);
                objectMapper.AssignValues(res);
                list.Add(t);
            }

            return list;
        }
    }
}