-- Generated by CSharp.lua Compiler
local System = System
local VoidSharp
System.import(function (out)
  VoidSharp = out.VoidSharp
end)
System.namespace("VoidSharp.VoidUI", function (namespace)
  namespace.class("Tabs", function (namespace)
    local SetAccentColor, SetMoveSpeed, AddTab, SelectTab, __ctor__
    __ctor__ = function (this)
      VoidSharp.Panel.__ctor__[1](this, "VoidUI.Tabs")
    end
    SetAccentColor = function (this, color)
      this.VGUIPanel.accentColor = color:ToGmodColor()
    end
    SetMoveSpeed = function (this, speed)
      this.VGUIPanel.animSpeed = speed
    end
    AddTab = function (this, text, panel, wide)
      this.VGUIPanel:AddTab(text, panel.VGUIPanel, wide)
    end
    SelectTab = function (this, index)
      this.VGUIPanel:SelectTab(index)
    end
    return {
      base = function (out)
        return {
          out.VoidSharp.Panel
        }
      end,
      SetAccentColor = SetAccentColor,
      SetMoveSpeed = SetMoveSpeed,
      AddTab = AddTab,
      SelectTab = SelectTab,
      __ctor__ = __ctor__,
      __metadata__ = function (out)
        return {
          methods = {
            { ".ctor", 0x6, nil },
            { "AddTab", 0x306, AddTab, System.String, out.VoidSharp.Panel, System.Int32 },
            { "SelectTab", 0x106, SelectTab, System.Int32 },
            { "SetAccentColor", 0x106, SetAccentColor, out.VoidSharp.Color },
            { "SetMoveSpeed", 0x106, SetMoveSpeed, System.Single }
          },
          class = { 0x6 }
        }
      end
    }
  end)
end)
