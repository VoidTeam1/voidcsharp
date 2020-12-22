namespace VoidSharp.Networking
{
    public interface INetworkSerializer
    {
        public void Write(NetworkWriter writer, object val);
        public object Read(NetworkReader reader);
    }


}