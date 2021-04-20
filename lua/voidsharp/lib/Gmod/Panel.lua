-- Generated by CSharp.lua Compiler
local System = System
local VoidSharp
System.import(function (out)
  VoidSharp = out.VoidSharp
end)
System.namespace("VoidSharp", function (namespace)
  namespace.class("Panel", function (namespace)
    local getX, setX, getY, setY, getIsHovered, getParent, setParent, Cast, 
    Add, Add1, Add2, SetSize, SetWide, SetTall, getHeight, setHeight, 
    getWidth, setWidth, SetPos, Center, MakePopup, Dock, DockMargin, Margin, 
    MarginLeft, MarginRight, MarginTop, MarginBottom, class, __ctor1__, __ctor2__
    __ctor1__ = function (this, name)
      this.VGUIPanel = VoidSharp.VGUI.Create(name)
      this.VGUIPanel.VoidSharpPanel = this
    end
    __ctor2__ = function (this, vguiPanel)
      this.VGUIPanel = vguiPanel
      this.VGUIPanel.VoidSharpPanel = this
    end
    getX = function (this)
      return this.VGUIPanel.x
    end
    setX = function (this, value)
      this.VGUIPanel.x = value
    end
    getY = function (this)
      return this.VGUIPanel.y
    end
    setY = function (this, value)
      this.VGUIPanel.y = value
    end
    getIsHovered = function (this)
      return this.VGUIPanel:IsHovered()
    end
    getParent = function (this)
      return class()
    end
    setParent = function (this, value)
      this.VGUIPanel:SetParent(value.VGUIPanel)
    end
    Cast = function (this, T)
      local default = T()
      default.VGUIPanel = this.VGUIPanel
      local t = default
      return t
    end
    -- <summary>
    -- Creates a new panel and parents it to the current panel.
    -- </summary>
    -- <param name="panel">The panel name.</param>
    Add = function (this, panel)
      local gPanel = this.VGUIPanel:Add(panel)
      local fPanel = System.new(class, 2, gPanel)
      return fPanel
    end
    -- <summary>
    -- Parents the supplied panel to the current panel.
    -- </summary>
    -- <param name="panel">The panel to add.</param>
    Add1 = function (this, panel)
      this.VGUIPanel:Add(panel.VGUIPanel)
      return panel
    end
    Add2 = function (this, T)
      local default = T()
      setParent(default, this)
      local t = default
      return t
    end
    -- <summary>
    -- Sets the size of the panel.
    -- </summary>
    -- <param name="w">The width.</param>
    -- <param name="h">The height.</param>
    SetSize = function (this, w, h)
      this.VGUIPanel:SetSize(w, h)
    end
    -- <summary>
    -- Sets the width of the panel.
    -- </summary>
    -- <param name="w">The width of the panel.</param>
    SetWide = function (this, w)
      this.VGUIPanel:SetWide(w)
    end
    -- <summary>
    -- Sets the height of the panel.
    -- </summary>
    -- <param name="h">The height of the panel.</param>
    SetTall = function (this, h)
      this.VGUIPanel:SetTall(h)
    end
    getHeight = function (this)
      return this.VGUIPanel:GetTall()
    end
    setHeight = function (this, value)
      this.VGUIPanel:SetTall(value)
    end
    getWidth = function (this)
      return this.VGUIPanel:GetWide()
    end
    setWidth = function (this, value)
      this.VGUIPanel:SetWide(value)
    end
    -- <summary>
    -- Sets the position of the panel.
    -- </summary>
    -- <param name="x">The X position.</param>
    -- <param name="y">The Y position.</param>
    SetPos = function (this, x, y)
      this.VGUIPanel:SetPos(x, y)
    end
    -- <summary>
    -- Centers the panel.
    -- </summary>
    Center = function (this)
      this.VGUIPanel:Center()
    end
    -- <summary>
    -- Makes the panel a popup.
    -- </summary>
    MakePopup = function (this)
      this.VGUIPanel:MakePopup()
    end
    -- <summary>
    -- Sets the dock type for the panel, making the panel "dock" in a certain direction, modifying it's position and size.
    -- </summary>
    -- <param name="dockType">The dock type.</param>
    Dock = function (this, dockType)
      this.VGUIPanel:Dock(dockType)
    end
    -- <summary>
    -- Sets the dock margin of the panel.
    -- The dock margin is the extra space that will be left around the edge when this element is docked inside its parent element.
    -- </summary>
    -- <param name="marginLeft">The left margin.</param>
    -- <param name="marginTop">The top margin.</param>
    -- <param name="marginRight">The right margin.</param>
    -- <param name="marginBottom">The bottom margin.</param>
    DockMargin = function (this, marginLeft, marginTop, marginRight, marginBottom)
      this.VGUIPanel:DockMargin(marginLeft, marginTop, marginRight, marginBottom)
    end
    -- <summary>
    -- Alias of <see cref="DockMargin"/>.
    -- </summary>
    Margin = function (this, marginLeft, marginTop, marginRight, marginBottom)
      DockMargin(this, marginLeft, marginTop, marginRight, marginBottom)
    end
    -- <summary>
    -- Sets the left margin of the panel.
    -- Requires VoidUI.
    -- </summary>
    MarginLeft = function (this, val)
      this.VGUIPanel:MarginLeft(val)
    end
    -- <summary>
    -- Sets the right margin of the panel.
    -- Requires VoidUI.
    -- </summary>
    MarginRight = function (this, val)
      this.VGUIPanel:MarginRight(val)
    end
    -- <summary>
    -- Sets the top margin of the panel.
    -- Requires VoidUI.
    -- </summary>
    MarginTop = function (this, val)
      this.VGUIPanel:MarginTop(val)
    end
    -- <summary>
    -- Sets the bottom margin of the panel.
    -- Requires VoidUI.
    -- </summary>
    MarginBottom = function (this, val)
      this.VGUIPanel:MarginBottom(val)
    end
    class = {
      getX = getX,
      setX = setX,
      getY = getY,
      setY = setY,
      getIsHovered = getIsHovered,
      getParent = getParent,
      setParent = setParent,
      Cast = Cast,
      Add = Add,
      Add1 = Add1,
      Add2 = Add2,
      SetSize = SetSize,
      SetWide = SetWide,
      SetTall = SetTall,
      getHeight = getHeight,
      setHeight = setHeight,
      getWidth = getWidth,
      setWidth = setWidth,
      SetPos = SetPos,
      Center = Center,
      MakePopup = MakePopup,
      Dock = Dock,
      DockMargin = DockMargin,
      Margin = Margin,
      MarginLeft = MarginLeft,
      MarginRight = MarginRight,
      MarginTop = MarginTop,
      MarginBottom = MarginBottom,
      __ctor__ = {
        __ctor1__,
        __ctor2__
      },
      __metadata__ = function (out)
        return {
          properties = {
            { "Height", 0x106, System.Int32, getHeight, setHeight },
            { "IsHovered", 0x206, System.Boolean, getIsHovered },
            { "Parent", 0x106, class, getParent, setParent },
            { "VGUIPanel", 0x6, System.Object },
            { "Width", 0x106, System.Int32, getWidth, setWidth },
            { "X", 0x106, System.Int32, getX, setX },
            { "Y", 0x106, System.Int32, getY, setY }
          },
          methods = {
            { ".ctor", 0x106, __ctor1__, System.String },
            { ".ctor", 0x106, __ctor2__, System.Object },
            { "Add", 0x186, Add, System.String, class },
            { "Add", 0x186, Add1, class, class },
            { "Add", 0x10086, Add2, function (T) return T end },
            { "Cast", 0x10086, Cast, function (T) return T end },
            { "Center", 0x6, Center },
            { "Dock", 0x106, Dock, System.Int32 },
            { "DockMargin", 0x406, DockMargin, System.Int32, System.Int32, System.Int32, System.Int32 },
            { "MakePopup", 0x6, MakePopup },
            { "Margin", 0x406, Margin, System.Int32, System.Int32, System.Int32, System.Int32 },
            { "MarginBottom", 0x106, MarginBottom, System.Int32 },
            { "MarginLeft", 0x106, MarginLeft, System.Int32 },
            { "MarginRight", 0x106, MarginRight, System.Int32 },
            { "MarginTop", 0x106, MarginTop, System.Int32 },
            { "SetPos", 0x206, SetPos, System.Int32, System.Int32 },
            { "SetSize", 0x206, SetSize, System.Int32, System.Int32 },
            { "SetTall", 0x106, SetTall, System.Int32 },
            { "SetWide", 0x106, SetWide, System.Int32 }
          },
          class = { 0x6 }
        }
      end
    }
    return class
  end)
end)
