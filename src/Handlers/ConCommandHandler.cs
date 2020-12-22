using System;
using VoidSharp;

namespace VoidSharp.Handlers
{
    public static class ConCommandHandler
    {
        /// <summary>
        /// Initializes concommands for usage in passed instance.
        /// </summary>
        /// <param name="instance">The instance of the class.</param>
        public static void InitializeConCommands(object instance)
        {
            var methods = ConCommandAttribute.GetAllConCommandAttributes(instance.GetType());
            foreach (var method in methods)
            {
                ConCommandAttribute hookAttribute =
                    (ConCommandAttribute) method.GetCustomAttributes(typeof(ConCommandAttribute), true)[0];

                string name = hookAttribute.Name;
                
                Globals.AddConCommand(name, (player, s, arg3, arg4) =>
                {
                    method.Invoke(instance, new object[] {player, s, arg3, arg4});
                });
            }
        }
    }
}