using System;

namespace VoidSharp {

    public class Player : Entity {
        protected Player(string className) : base(className)
        {
        }

        /// <summary>
        /// Returns the player's nickname.
        /// </summary>
        public string Nick => GmodEntity.Nick();
        
        /// <summary>
        /// Returns the player's SteamID. In singleplayer, this will be STEAM_ID_PENDING serverside.
        /// For Bots this will return BOT on the server and on the client it returns NULL.
        /// </summary>
        public string SteamId => GmodEntity.SteamID();
        
        /// <summary>
        /// Returns the player's 64-bit SteamID aka CommunityID.
        /// </summary>
        public string SteamId64 => GmodEntity.SteamID64();
        
        /// <summary>
        /// Checks if the player is alive.
        /// </summary>
        public bool Alive => GmodEntity.Alive();
    }
    
}
