using VoidSharp;

namespace VoidSharp.Networking.Serializers
{
    public class ColorSerializer : INetworkSerializer
    {
        public void Write(NetworkWriter writer, object val)
        {
            writer.WriteColor((Color) val);
        }

        public object Read(NetworkReader reader)
        {
            return reader.ReadColor();
        }
    }
}