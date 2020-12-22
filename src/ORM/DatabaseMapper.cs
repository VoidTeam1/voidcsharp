using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using VoidSharp;

namespace VoidSharp.ORM
{
    /// <summary>
    /// Maps an object to a database and vice-versa.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DatabaseMapper<T> where T : new()
    {
        private Database Database { get; set; }

        public DatabaseMapper(Database database)
        {
            Database = database;
        }
        
    }
}