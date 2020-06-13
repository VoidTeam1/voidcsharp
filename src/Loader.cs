using System;

namespace EntityTest
{
    class Program {

        static void Main(string[] args)
        {
            bool isClient = Globals.IsClient();
            bool isServer = Globals.IsServer();

            Console.WriteLine("EntityTest loader loaded!");

            if (isServer) {
                EntityTest.Server.Loader.Initialize();
            }

            if (isClient) {
                EntityTest.Client.Loader.Initialize();
            }
        }

    }
}