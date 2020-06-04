using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

using System.Drawing;

namespace Test
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Loaded!");

            ChatCommand command = new ChatCommand("!gg");
        }
    }

}