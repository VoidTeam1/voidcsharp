using System;

namespace VoidSharp
{
    public static class Globals
    {
        /// @CSharpLua.Template = "_G"
        public static dynamic G;
        public static dynamic Game => G.game;
        public static dynamic Ents => G.ents;
        public static dynamic Players => G.player;
        public static dynamic Hook => G.hook;
        public static dynamic Util => G.util;
        public static dynamic Surface => G.surface;
        public static dynamic VGUI => G.vgui;
        public static dynamic DarkRP => G.DarkRP;
        public static dynamic ConCommand => G.concommand;
        public static dynamic Team => G.team;
        public static dynamic VoidLib => G.VoidLib;
        
        public static void ConsoleLog(object[] args)
        {
            /*
            [[
                MsgC(unpack(args))
            ]] 
            */
        }

        public static void AddConCommand(string name, Action<Player, string, string[], string> callback, Action<string, string> autoComplete = null, string helpText = null, int flags = 0)
        {
            dynamic func = ConCommand.Add;
            func(name, callback, autoComplete, helpText, flags);
        }

        public static void Error(string err)
        {
            G.error(err);
        }
    }
}