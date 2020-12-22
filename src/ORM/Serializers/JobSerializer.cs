using VoidSharp;
using VoidSharp.DarkRP;

namespace VoidSharp.ORM.Serializers
{
    public class JobSerializer : ISerializerBase
    {
        public string Serialize(object obj, IDatabaseDriver databaseDriver = null)
        {
            Job job = (Job) obj;
            return "'" + job.Command + "'";
        }

        public object Deserialize(object obj)
        {
            return DarkRP.DarkRP.GetJobByCommand((string) obj);
        }
    }
}