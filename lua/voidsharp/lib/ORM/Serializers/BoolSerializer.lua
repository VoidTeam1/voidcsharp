-- Generated by CSharp.lua Compiler
local System = System
System.namespace("VoidSharp.ORM.Serializers", function (namespace)
  namespace.class("BoolSerializer", function (namespace)
    local Serialize, Deserialize
    Serialize = function (this, obj, databaseDriver)
      local boolean = System.cast(System.Boolean, obj)
      return boolean and "TRUE" or "FALSE"
    end
    Deserialize = function (this, obj)
      local str = System.cast(System.String, obj)
      local result = str == "TRUE" or str == "true" or str == "1"
      return result
    end
    return {
      base = function (out)
        return {
          out.VoidSharp.ORM.ISerializerBase
        }
      end,
      Serialize = Serialize,
      Deserialize = Deserialize,
      __metadata__ = function (out)
        return {
          methods = {
            { "Deserialize", 0x186, Deserialize, System.Object, System.Object },
            { "Serialize", 0x286, Serialize, System.Object, out.VoidSharp.IDatabaseDriver, System.String }
          },
          class = { 0x6 }
        }
      end
    }
  end)
end)