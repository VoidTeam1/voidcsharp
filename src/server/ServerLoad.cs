using System;
using System.Linq;

using System.Collections.Generic;
using System.Configuration;

using System.Threading.Tasks;

using Void.GLua;
using Void.ORM;

namespace EntityTest.Server
{
    static class Loader
    {
        public static void Initialize()
        {
            Console.WriteLine("Server loaded! HELLO THERE!");

            InitDatabase();
        }

        private async static void InitDatabase()
        {
            await Database.Connect();
            
            QueryBuilder query = new QueryBuilder("orm_testquery");
            query.InsertColumn("price", 2400);
            query.InsertColumn("sid", "76258456");
            await query.Insert();

            QueryBuilder q = new QueryBuilder("orm_testquery");
            var r = await q.Select();
            Console.WriteLine(r);

        }
    }

}