-- Generated by CSharp.lua Compiler
local System = System
local VoidSharp
System.import(function (out)
  VoidSharp = out.VoidSharp
end)
System.namespace("VoidSharp.VoidUI", function (namespace)
  namespace.class("Grid", function (namespace)
    local getHorizontalMargin, setHorizontalMargin, getVerticalMargin, setVerticalMargin, AddCell, AutoSize, Skip, Clear, 
    __ctor__
    __ctor__ = function (this)
      VoidSharp.Panel.__ctor__[1](this, "VoidUI.Grid")
    end
    getHorizontalMargin = function (this)
      return this.VGUIPanel.GetHorizontalMargin
    end
    setHorizontalMargin = function (this, value)
      this.VGUIPanel:SetHorizontalMargin(value)
    end
    getVerticalMargin = function (this)
      return this.VGUIPanel.GetVerticalMargin
    end
    setVerticalMargin = function (this, value)
      this.VGUIPanel:SetVerticalMargin(value)
    end
    AddCell = function (this, panel, fixedWidth, fixedHeight)
      this.VGUIPanel:AddCell(panel, fixedWidth, fixedHeight)
    end
    AutoSize = function (this)
      this.VGUIPanel:AutoSize()
    end
    Skip = function (this)
      this.VGUIPanel:Skip()
    end
    Clear = function (this)
      this.VGUIPanel:Clear()
    end
    return {
      base = function (out)
        return {
          out.VoidSharp.Panel
        }
      end,
      getHorizontalMargin = getHorizontalMargin,
      setHorizontalMargin = setHorizontalMargin,
      getVerticalMargin = getVerticalMargin,
      setVerticalMargin = setVerticalMargin,
      AddCell = AddCell,
      AutoSize = AutoSize,
      Skip = Skip,
      Clear = Clear,
      __ctor__ = __ctor__,
      __metadata__ = function (out)
        return {
          methods = {
            { ".ctor", 0x6, nil },
            { "AddCell", 0x306, AddCell, out.VoidSharp.Panel, System.Boolean, System.Boolean },
            { "AutoSize", 0x6, AutoSize },
            { "Clear", 0x6, Clear },
            { "Skip", 0x6, Skip }
          },
          properties = {
            { "HorizontalMargin", 0x106, System.Int32, getHorizontalMargin, setHorizontalMargin },
            { "VerticalMargin", 0x106, System.Int32, getVerticalMargin, setVerticalMargin }
          },
          class = { 0x6 }
        }
      end
    }
  end)
end)