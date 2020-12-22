using System;
using VoidSharp;
using VoidSharp.DarkRP;

namespace VoidSharp.Networking.Serializers
{
    public class JobSerializer : INetworkSerializer
    {
        public void Write(NetworkWriter writer, object val)
        {
            if (val is null)
            {
                writer.WriteUInt(0, 16);
            }
            else
            {
                Job job = (Job) val;
                writer.WriteUInt(job.Team.Index, 16);
            }
        }

        public object Read(NetworkReader reader)
        {
            int sn = (int) reader.ReadUInt(16);
            if (sn == 0)
            {
                return null;
            }

            return new Job(new Team(sn));
        }
    }
}