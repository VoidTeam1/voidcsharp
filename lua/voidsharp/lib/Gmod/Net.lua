-- Generated by CSharp.lua Compiler
local System = System
local ListObject = System.List(System.Object)
System.namespace("VoidSharp", function (namespace)
  namespace.class("Net", function (namespace)
    local AddNetworkString, Start, Send, Send1, Broadcast, WriteString, ReadString, Receive, 
    SendToServer, Receive1
    -- <summary>
    -- </summary>
    AddNetworkString = function (str)
    end
    -- <summary>
    -- </summary>
    Start = function (msg)
    end
    Send = function (player)
      local send = _G.net.Send
      send(player.GmodEntity)
    end
    Send1 = function (players)
      local list = ListObject()
      for _, player in System.each(players) do
        list:Add(player.GmodEntity)
      end

      local send = _G.net.Send
      send(list:ToArray())
    end
    -- <summary>
    -- </summary>
    Broadcast = function ()
    end
    -- <summary>
    -- </summary>
    WriteString = function (str)
      System.throw(System.NotImplementedException())
    end
    -- <summary>
    -- </summary>
    ReadString = function ()
      System.throw(System.NotImplementedException())
    end
    Receive = function (id, action)
      net.Receive(id, action)
    end
    -- <summary>
    -- </summary>
    SendToServer = function ()
    end
    Receive1 = function (id, action)
      net.Receive(id, action)
    end
    return {
      AddNetworkString = AddNetworkString,
      Start = Start,
      Send = Send,
      Send1 = Send1,
      Broadcast = Broadcast,
      WriteString = WriteString,
      ReadString = ReadString,
      Receive = Receive,
      SendToServer = SendToServer,
      Receive1 = Receive1,
      __metadata__ = function (out)
        return {
          methods = {
            { "AddNetworkString", 0x10E, AddNetworkString, System.String },
            { "Broadcast", 0xE, Broadcast },
            { "ReadString", 0x8E, ReadString, System.String },
            { "Receive", 0x20E, Receive, System.String, System.Delegate(System.Int32, System.Void) },
            { "Receive", 0x20E, Receive1, System.String, System.Delegate(System.Int32, System.Object, System.Void) },
            { "Send", 0x10E, Send, out.VoidSharp.Player },
            { "Send", 0x10E, Send1, System.Array(out.VoidSharp.Player) },
            { "SendToServer", 0xE, SendToServer },
            { "Start", 0x10E, Start, System.String },
            { "WriteString", 0x18E, WriteString, System.String, System.String }
          },
          class = { 0xE }
        }
      end
    }
  end)
end)
