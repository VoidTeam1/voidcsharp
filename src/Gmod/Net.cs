﻿using System;
 using System.Collections.Generic;

 namespace VoidSharp
{
    public static class Net
    {
        /// <summary>
        /// @CSharpLua.Template = "util.AddNetworkString({0})"
        /// </summary>
        public static void AddNetworkString(string str)
        {
            
        }
        
        /// <summary>
        /// @CSharpLua.Template = "net.Start({0})"
        /// </summary>
        public static void Start(string msg)
        {
            
        }
        
        public static void Send(Player player)
        {
            dynamic send = Globals.G.net.Send;
            send(player.GmodEntity);
        }
        
        public static void Send(Player[] players)
        {
            List<dynamic> list = new List<dynamic>();
            foreach (Player player in players)
            {
                list.Add(player.GmodEntity);
            }

            dynamic send = Globals.G.net.Send;
            send(list.ToArray());
        }
        
        /// <summary>
        /// @CSharpLua.Template = "net.Broadcast()"
        /// </summary>
        public static void Broadcast()
        {
            
        }
        
        /// <summary>
        /// @CSharpLua.Template = "net.WriteString({0})"
        /// </summary>
        public static string WriteString(string str)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// @CSharpLua.Template = "net.ReadString()"
        /// </summary>
        public static string ReadString()
        {
            throw new NotImplementedException();
        }
        
        public static void Receive(string id, Action<int> action)
        {
            /*
            [[
            net.Receive(id, action)
            ]] 
            */
        }

        /// <summary>
        /// @CSharpLua.Template = "net.SendToServer()"
        /// </summary>
        public static void SendToServer()
        {
            
        }
        public static void Receive(string id, Action<int, Player> action)
        {
            /*
            [[
            net.Receive(id, action)
            ]] 
            */
        }
    }
}