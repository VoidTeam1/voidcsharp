-- Generated by CSharp.lua Compiler
local System = System
local VoidSharpUtilities
System.import(function (out)
  VoidSharpUtilities = VoidSharp.Utilities
end)
System.namespace("VoidSharp", function (namespace)
  namespace.class("Program", function (namespace)
    local Main
    Main = function (args)
      VoidSharpUtilities.Logger.LogInfo("Successfully loaded!")
    end
    return {
      Main = Main,
      __metadata__ = function (out)
        return {
          methods = {
            { "Main", 0x10E, Main, System.Array(System.String) }
          },
          class = { 0xE }
        }
      end
    }
  end)
end)