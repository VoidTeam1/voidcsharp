﻿
using System;
using System.Collections.Generic;

namespace VoidSharp
{
    public class Team
    {
        /// <summary>
        /// The teamIndex (TEAM number) of the team.
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// The team name.
        /// </summary>
        public string Name => GetName(Index);
        
        /// <summary>
        /// The team color.
        /// </summary>
        public Color Color => GetColor(Index);
        
        /// <summary>
        /// The classname of the team.
        /// </summary>
        public string Class => GetClass(Index);
        
        /// <summary>
        /// List of players inside the team.
        /// </summary>
        public Player[] Players => GetPlayers(Index);
        
        /// <summary>
        /// Spawnpoint of the team.
        /// </summary>
        public Vector SpawnPoint => GetSpawnPoint(Index);
        
        /// <summary>
        /// Multiple spawnpoints of the team.
        /// </summary>
        public Vector[] SpawnPoints => GetSpawnPoints(Index);
        
        /// <summary>
        /// Number of players in the team.
        /// </summary>
        public int PlayerCount => NumPlayers(Index);

        public Team(int index)
        {
            Index = index;
        }
        
        /// <summary>
        /// Name of the team.
        /// </summary>
        private static string GetName(int teamIndex)
        {
            return Globals.Team.GetName(teamIndex);
        }

        /// <summary>
        /// All extisting teams.
        /// </summary>
        public static List<Team> GetAllTeams()
        {
            var teams = Globals.Team.GetAllTeams();
            List<Team> returnVal = new List<Team>();

            foreach (dynamic team in teams)
            {
                returnVal.Add(new Team(team));
            }

            return returnVal;
        }
        
        /// <summary>
        /// Returns the amount of players in a team.
        /// </summary>
        private static int NumPlayers(int teamIndex)
        {
            return Globals.Team.NumPlayers(teamIndex);
        }
        
        /// <summary>
        /// Returns a table of valid spawnpoint classes the team can use.
        /// </summary>
        private static Vector GetSpawnPoint(int teamIndex)
        {
            return Globals.Team.GetSpawnPoint(teamIndex);
        }
        
        /// <summary>
        /// Returns a table of valid spawnpoint entities the team can use.
        /// </summary>
        private static Vector[] GetSpawnPoints(int teamIndex)
        {
            return Globals.Team.GetSpawnPoints(teamIndex);
        }
        
        /// <summary>
        /// Returns the selectable classes for the given team.
        /// </summary>
        private static string GetClass(int teamIndex)
        {
            return Globals.Team.GetClass(teamIndex);
        }
        
        /// <summary>
        /// Returns a table with all player of the specified team.
        /// </summary>
        private static Player[] GetPlayers(int teamIndex)
        {
            dynamic gmodPlayers = Globals.Team.GetPlayers(teamIndex);
            List<Player> players = new List<Player>();

            foreach (var player in gmodPlayers)
            {
                var ply = new Entity(player);
                players.Add((Player)ply);
            }

            return players.ToArray();
        }

        /// <summary>
        /// Returns the team's color.
        /// </summary>
        private static Color GetColor(int teamIndex)
        {
            var gmodColor = Globals.Team.GetColor(teamIndex);
            return VoidSharp.Color.FromGmodColor(gmodColor);
        }
    }
}