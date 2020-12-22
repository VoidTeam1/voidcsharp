#define DEBUG

using System;
using System.Collections.Generic;
using VoidSharp;

namespace VoidSharp.Utilities
{
    public static class Logger
    {
        private static List<dynamic> CreatePrefix(string type, Color color = null)
        {
            var args = new List<dynamic>() {
                new Color(87, 180, 242).ToGmodColor(),
                "[VoidSharp] ",
                color != null ? color.ToGmodColor() : new Color(87, 180, 242).ToGmodColor(),
                $"[{type}] ",
                new Color(255, 255, 255).ToGmodColor(),
            };

            return args;
        }
        
        /// <summary>
        /// Logs an info message to the console.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="customPrefix">Custom prefix, if applicable.</param>
        public static void LogInfo(object message, string customPrefix = null)
        {
            List<dynamic> msg = CreatePrefix("INFO");
            if (customPrefix != null)
            {
                msg = CreatePrefix(customPrefix);
                msg.Add(new Color(87, 180, 242).ToGmodColor());
                msg.Add("[INFO] ");
                msg.Add(new Color(255, 255, 255).ToGmodColor());
            }
            
            msg.Add(message);
            msg.Add("\n");
            Globals.ConsoleLog(msg.ToArray());
        }
        
        /// <summary>
        /// Logs an error message to the console.
        /// </summary>
        /// <param name="message">The error message.</param>
        public static void LogError(object message)
        {
            List<dynamic> msg = CreatePrefix("ERROR", new Color(255, 0, 0));
            msg.Add(new Color(255, 0, 0).ToGmodColor());
            msg.Add(message);
            msg.Add("\n");
            Globals.ConsoleLog(msg.ToArray());
        }

        /// <summary>
        /// Logs a debug message to the console. Only does something if DEBUG symbol is defined.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="customPrefix"></param>
        public static void LogDebug(object message, string customPrefix = null)
        {
            #if DEBUG
            List<dynamic> msg = CreatePrefix("DEBUG");
            if (customPrefix != null)
            {
                msg = CreatePrefix(customPrefix);
                msg.Add(new Color(252, 186, 3).ToGmodColor());
                msg.Add("[INFO] ");
                msg.Add(new Color(255, 255, 255).ToGmodColor());
            }
            
            msg.Add(message);
            msg.Add("\n");
            Globals.ConsoleLog(msg.ToArray());
            #endif
        }
    }
}