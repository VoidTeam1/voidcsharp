using System;

namespace VoidSharp
{
    public static class Realm {
        /// <summary>
        /// Returns if its a server
        /// </summary>
        public static bool IsServer()
        {
            return Globals.G.SERVER;
        }

        /// <summary>
        /// Returns if its a client
        /// </summary>
        public static bool IsClient()
        {
            return Globals.G.CLIENT;
        }
    }
}