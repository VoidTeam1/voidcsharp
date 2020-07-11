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
            
            

        }
    }

}