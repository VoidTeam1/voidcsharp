namespace VoidSharp.Networking.Serializers
{
    public class BoolSerializer : INetworkSerializer
    {
        public void Write(NetworkWriter writer, object val)
        {
            writer.WriteBool((bool) val);
        }

        public object Read(NetworkReader reader)
        {
            return reader.ReadBool();
        }
    }
}