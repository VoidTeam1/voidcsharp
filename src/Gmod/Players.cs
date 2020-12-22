using System.Collections.Generic;

namespace VoidSharp
{

    public static class Players {
        
        /// <summary>
        /// Gets all the current players in the server (not including connecting clients).
        /// </summary>
        public static Player[] GetAll()
        {
            List<Player> players = new List<Player>();
            foreach (dynamic player in Globals.Players.GetAll())
            {
                var ply = new Entity(player);
                players.Add((Player)ply);
            }
            return players.ToArray();
        }
    }
}
