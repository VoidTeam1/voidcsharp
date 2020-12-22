﻿using System;

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
        
        /// <summary>
        /// @CSharpLua.Template = "net.Send({0})"
        /// </summary>
        public static void Send(Player player)
        {
            
        }
        
        /// <summary>
        /// @CSharpLua.Template = "net.Send({0})"
        /// </summary>
        public static void Send(Player[] players)
        {
            
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