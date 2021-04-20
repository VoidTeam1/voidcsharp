using System;

namespace VoidSharp {

    public class Player : Entity {
        public Player(object gmodEntity) : base(gmodEntity)
        {
            
        }

        public static Player LocalPlayer()
        {
            return new Player(Globals.G.LocalPlayer());
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

        /// <summary>
        /// Prints a message to the player's chat.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public void ChatPrint(string message)
        {
            GmodEntity.ChatPrint(message);
        }
    }
    
}
