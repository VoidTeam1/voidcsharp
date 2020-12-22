using System;

namespace VoidSharp
{
    public static class VoidLib
    {
        /// <summary>
        /// Creates a notification. (CLIENTSIDE ONLY)
        /// </summary>
        /// <param name="upper">The upper text.</param>
        /// <param name="text">The lower text.</param>
        /// <param name="color">The color of the notification.</param>
        /// <param name="length">The length of the notification (in seconds)</param>
        public static void Notify(string upper, string text, Color color, int length)
        {
            if (!Realm.IsClient()) throw new Exception("Running a client-side method from server!");
            
            dynamic func = Globals.VoidLib.Notify;
            func(upper, text, color, length);
        }
        
        /// <summary>
        /// Notifies a player. (SERVERSIDE ONLY)
        /// </summary>
        /// <param name="ply">The player to notify.</param>
        /// <param name="upper">The upper text.</param>
        /// <param name="text">The lower text.</param>
        /// <param name="color">The color of the notification.</param>
        /// <param name="length">The length of the notification (in seconds)</param>
        public static void Notify(Player ply, string upper, string text, Color color, int length)
        {
            if (!Realm.IsServer()) throw new Exception("Running a server-side method from client!");
            
            dynamic func = Globals.VoidLib.Notify;
            func(ply, upper, text, color, length);
        }

        /// <summary>
        /// Registers an addon to VoidLib Tracker.
        /// </summary>
        /// <param name="addonName">The addon name. (global tables have to match)</param>
        /// <param name="addonId">The GModStore ID of the addon.</param>
        /// <param name="license">The license of the customer.</param>
        public static void RegisterAddon(string addonName, int addonId, string license)
        {
            Globals.VoidLib.Tracker.RegisterAddon(addonName, addonId, license);
        }
    }
}