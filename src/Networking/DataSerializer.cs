using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VoidSharp.ORM;
using VoidSharp;
using VoidSharp.DarkRP;
using VoidSharp.Networking.Serializers;

namespace VoidSharp.Networking
{
    public class DataSerializer
    {

        public void Write<T>(T value) where T : class
        {
            NetworkWriter writer = new NetworkWriter();
            foreach (var property in typeof(T).GetProperties())
            {
                WriteSingle(writer, property.PropertyType, property.GetValue(value));
            }
        }


        public object Read(Type type)
        {
            object readClass = Activator.CreateInstance(type);
            NetworkReader reader = new NetworkReader();
            foreach (var property in type.GetProperties())
            {
                dynamic val = ReadSingle(reader, property.PropertyType);
                
                var propInfo = type.GetProperties().FirstOrDefault(x => x.Name == property.Name);
                propInfo?.SetValue(readClass, val);
            }
            return readClass;
        }
        
        public T Read<T>() where T : class, new()
        {
            T readClass = new T();
            
            NetworkReader reader = new NetworkReader();
            foreach (var property in typeof(T).GetFields())
            {
                dynamic val = ReadSingle(reader, property.FieldType);
                
                var propInfo = typeof(T).GetProperties().FirstOrDefault(x => x.Name == property.Name);
                propInfo?.SetValue(readClass, val);
            }

            return readClass;
        }

        public void WriteSingle(NetworkWriter writer, Type type, object value)
        {
            bool success = SerializerMap.Serializers.TryGetValue(type, out var serializer);
            if (!success)
            {
                throw new Exception($"There is no serializer for the type {type.Name}!");
            }
            
            serializer.Write(writer, value);
        }

        public object ReadSingle(NetworkReader reader, Type type)
        {
            bool success = SerializerMap.Serializers.TryGetValue(type, out var serializer);
            if (!success)
            {
                throw new Exception($"There is no serializer for the type {type.Name}!");
            }
            
            return serializer.Read(reader);
        }
        
        public static void RegisterSerializers()
        {
            SerializerMap.RegisterSerializer<string, StringSerializer>();
            SerializerMap.RegisterSerializer<int, IntegerSerializer>();
            SerializerMap.RegisterSerializer<uint, UIntegerSerializer>();
            SerializerMap.RegisterSerializer<Color, ColorSerializer>();
            SerializerMap.RegisterSerializer<bool, BoolSerializer>();
            SerializerMap.RegisterSerializer<Job, JobSerializer>();
            SerializerMap.RegisterSerializer<DateTime, DateTimeSerializer>();
        }
    }
}
