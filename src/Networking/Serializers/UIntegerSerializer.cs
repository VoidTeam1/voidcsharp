namespace VoidSharp.Networking.Serializers
{
    public class UIntegerSerializer : INetworkSerializer
    {
        public void Write(NetworkWriter writer, object val)
        {
            writer.WriteUInt((int)val, 32);
        }

        public object Read(NetworkReader reader)
        {
            return (int) reader.ReadUInt(32);
        }
    }
}