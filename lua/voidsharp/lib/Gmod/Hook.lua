-- Generated by CSharp.lua Compiler
local System = System
local VoidSharp
System.import(function (out)
  VoidSharp = out.VoidSharp
end)
System.namespace("VoidSharp", function (namespace)
  namespace.class("Hook", function (namespace)
    local Add, Remove, Run, GetTable
    -- <summary>
    -- Add a hook to be called upon the given event occurring.
    -- </summary>
    Add = function (name, id, hookCallback)
      local func = VoidSharp.Globals.getHook().Add
      func(name, id, hookCallback)
    end
    -- <summary>
    -- Removes the hook with the supplied identifier from the given event.
    -- </summary>
    Remove = function (name, id)
      local func = VoidSharp.Globals.getHook().Remove
      func(name, id)
    end
    -- <summary>
    -- Calls hooks associated with the given event.
    -- </summary>
    Run = function (name, args)
      local func = VoidSharp.Globals.getHook().Run
      func(name, args)
    end
    -- <summary>
    -- Returns a list of all the hooks registered with hook.Add.
    -- </summary>
    -- <returns></returns>
    GetTable = function ()
      return VoidSharp.Globals.getHook():GetTable()
    end
    return {
      Add = Add,
      Remove = Remove,
      Run = Run,
      GetTable = GetTable,
      __metadata__ = function (out)
        return {
          methods = {
            { "Add", 0x30E, Add, System.String, System.String, System.Delegate(System.Array(System.Object), System.Void) },
            { "GetTable", 0x8E, GetTable, System.Object },
            { "Remove", 0x20E, Remove, System.String, System.String },
            { "Run", 0x20E, Run, System.String, System.Array(System.Object) }
          },
          class = { 0xE }
        }
      end
    }
  end)
end)