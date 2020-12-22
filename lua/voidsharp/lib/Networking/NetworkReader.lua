-- Generated by CSharp.lua Compiler
local System = System
local VoidSharp
System.import(function (out)
  VoidSharp = out.VoidSharp
end)
System.namespace("VoidSharp.Networking", function (namespace)
  namespace.class("NetworkReader", function (namespace)
    local ReadString, ReadInt, ReadUInt, ReadBool, ReadDouble, WriteFloat, ReadEntity, ReadVector, 
    ReadColor
    -- <summary>
    -- </summary>
    ReadString = function (this)
      System.throw(System.NotImplementedException())
    end
    -- <summary>
    -- </summary>
    ReadInt = function (this, bitCount)
      System.throw(System.NotImplementedException())
    end
    -- <summary>
    -- </summary>
    ReadUInt = function (this, bitCount)
      System.throw(System.NotImplementedException())
    end
    -- <summary>
    -- </summary>
    ReadBool = function (this)
      System.throw(System.NotImplementedException())
    end
    -- <summary>
    -- </summary>
    ReadDouble = function (this)
      System.throw(System.NotImplementedException())
    end
    -- <summary>
    -- </summary>
    WriteFloat = function (this)
      System.throw(System.NotImplementedException())
    end
    -- <summary>
    -- </summary>
    ReadEntity = function (this)
      System.throw(System.NotImplementedException())
    end
    -- <summary>
    -- </summary>
    ReadVector = function (this)
      System.throw(System.NotImplementedException())
    end
    ReadColor = function (this)
      local gmodColor = nil
      gmodColor = net.ReadColor()
      return VoidSharp.Color.FromGmodColor(gmodColor)
    end
    return {
      ReadString = ReadString,
      ReadInt = ReadInt,
      ReadUInt = ReadUInt,
      ReadBool = ReadBool,
      ReadDouble = ReadDouble,
      WriteFloat = WriteFloat,
      ReadEntity = ReadEntity,
      ReadVector = ReadVector,
      ReadColor = ReadColor,
      __metadata__ = function (out)
        return {
          methods = {
            { "ReadBool", 0x86, ReadBool, System.Boolean },
            { "ReadColor", 0x86, ReadColor, out.VoidSharp.Color },
            { "ReadDouble", 0x86, ReadDouble, System.Double },
            { "ReadEntity", 0x86, ReadEntity, out.VoidSharp.Entity },
            { "ReadInt", 0x186, ReadInt, System.Int32, System.Object },
            { "ReadString", 0x86, ReadString, System.String },
            { "ReadUInt", 0x186, ReadUInt, System.Int32, System.Object },
            { "ReadVector", 0x86, ReadVector, out.Vector },
            { "WriteFloat", 0x86, WriteFloat, System.Single }
          },
          class = { 0x6 }
        }
      end
    }
  end)
end)