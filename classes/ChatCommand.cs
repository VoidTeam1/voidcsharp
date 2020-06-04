using System;
using System.Collections.Generic;

public class ChatCommand {
    public string Command { get; set; }

    public ChatCommand (string command) {
        Command = command;
        
        Hook.Add("PlayerSay", "ChatCommand." + command, (dynamic[] args) => {
            Player sender = args[0];
            string text = args[1];

            if (text == command) {
                dynamic[] retArgs = {""};
                Hook.Return(retArgs);
            }
        });

    }
}