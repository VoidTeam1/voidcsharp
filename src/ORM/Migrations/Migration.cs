using System.Threading.Tasks;
using VoidSharp.ORM;

namespace VoidSharp.ORM.Migrations
{
    public abstract class Migration
    {
        public abstract int Version { get; set; }

        public abstract Task Up(Database database);
    }
}