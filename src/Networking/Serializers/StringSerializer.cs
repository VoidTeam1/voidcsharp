namespace VoidSharp.Networking.Serializers
{
    public class StringSerializer : INetworkSerializer
    {
        public void Write(NetworkWriter writer, object val)
        {
            writer.WriteString((string)val);
        }

        public object Read(NetworkReader reader)
        {
            return reader.ReadString();
        }
    }
}