-- Generated by CSharp.lua Compiler
local System = System
local VoidSharp
System.import(function (out)
  VoidSharp = out.VoidSharp
end)
System.namespace("VoidSharp.Derma", function (namespace)
  namespace.class("Frame", function (namespace)
    local getTitle, setTitle, Close, __ctor__
    __ctor__ = function (this)
      VoidSharp.Panel.__ctor__[1](this, "DFrame")
    end
    getTitle = function (this)
      return this.VGUIPanel:GetTitle()
    end
    setTitle = function (this, value)
      this.VGUIPanel:SetTitle(value)
    end
    Close = function (this)
      this.VGUIPanel:Close()
    end
    return {
      base = function (out)
        return {
          out.VoidSharp.Panel
        }
      end,
      getTitle = getTitle,
      setTitle = setTitle,
      Close = Close,
      __ctor__ = __ctor__,
      __metadata__ = function (out)
        return {
          methods = {
            { ".ctor", 0x6, nil },
            { "Close", 0x6, Close }
          },
          properties = {
            { "Title", 0x106, System.String, getTitle, setTitle }
          },
          class = { 0x6 }
        }
      end
    }
  end)
end)
