using System;
using VoidSharp.Enums;

namespace VoidSharp
{
    public class Panel
    {
        // ReSharper disable once InconsistentNaming
        public dynamic VGUIPanel { get; }

        /// <summary>
        /// The X panel of the position.
        /// </summary>
        public int X
        {
            get => VGUIPanel.x;
            set => VGUIPanel.x = value;
        }

        /// <summary>
        /// The Y position of the panel.
        /// </summary>
        public int Y
        {
            get => VGUIPanel.y;
            set => VGUIPanel.y = value;
        }

        public bool IsHovered
        {
            get => VGUIPanel.IsHovered();
        }

        /// <summary>
        /// The parent of the panel.
        /// </summary>
        public Panel Parent
        {
            get => new Panel(VGUIPanel);
            set => VGUIPanel.SetParent(value.VGUIPanel);
        }

        public Panel(string name)
        {
            VGUIPanel = VGUI.Create(name);
            VGUIPanel.VoidSharpPanel = this;
        }

        public Panel(dynamic vguiPanel)
        {
            VGUIPanel = vguiPanel;
            VGUIPanel.VoidSharpPanel = this;
        }


        #region Parenting
        
        /// <summary>
        /// Creates a new panel and parents it to the current panel.
        /// </summary>
        /// <param name="panel">The panel name.</param>
        public Panel Add(string panel)
        {
            Panel resultPanel = new Panel(panel);
            VGUIPanel.Add(resultPanel.VGUIPanel);
            return resultPanel;
        }
        
        /// <summary>
        /// Parents the supplied panel to the current panel.
        /// </summary>
        /// <param name="panel">The panel to add.</param>
        public Panel Add(Panel panel)
        {
            VGUIPanel.Add(panel.VGUIPanel);
            return panel;
        }
        
        #endregion
        
        #region Positioning

        /// <summary>
        /// Sets the size of the panel.
        /// </summary>
        /// <param name="w">The width.</param>
        /// <param name="h">The height.</param>
        public void SetSize(int w, int h)
        {
            VGUIPanel.SetSize(w, h);
        }

        /// <summary>
        /// Sets the width of the panel.
        /// </summary>
        /// <param name="w">The width of the panel.</param>
        public void SetWide(int w)
        {
            VGUIPanel.SetWide(w);
        }

        /// <summary>
        /// Sets the height of the panel.
        /// </summary>
        /// <param name="h">The height of the panel.</param>
        public void SetTall(int h)
        {
            VGUIPanel.SetTall(h);
        }

        /// <summary>
        /// Sets the position of the panel.
        /// </summary>
        /// <param name="x">The X position.</param>
        /// <param name="y">The Y position.</param>
        public void SetPos(int x, int y)
        {
            VGUIPanel.SetPos(x, y);
        }
        
        /// <summary>
        /// Centers the panel.
        /// </summary>
        public void Center()
        {
            VGUIPanel.Center();
        }
        
        #endregion
        
        #region Operations

        /// <summary>
        /// Makes the panel a popup.
        /// </summary>
        public void MakePopup()
        {
            VGUIPanel.MakePopup();
        }
        
        #endregion
        
        #region Docking

        /// <summary>
        /// Sets the dock type for the panel, making the panel "dock" in a certain direction, modifying it's position and size.
        /// </summary>
        /// <param name="dockType">The dock type.</param>
        public void Dock(DockType dockType)
        {
            VGUIPanel.Dock(dockType);
        }

        /// <summary>
        /// Sets the dock margin of the panel.
        /// The dock margin is the extra space that will be left around the edge when this element is docked inside its parent element.
        /// </summary>
        /// <param name="marginLeft">The left margin.</param>
        /// <param name="marginTop">The top margin.</param>
        /// <param name="marginRight">The right margin.</param>
        /// <param name="marginBottom">The bottom margin.</param>
        public void DockMargin(int marginLeft, int marginTop, int marginRight, int marginBottom)
        {
            VGUIPanel.DockMargin(marginLeft, marginTop, marginRight, marginBottom);
        }
        
        /// <summary>
        /// Alias of <see cref="DockMargin"/>.
        /// </summary>
        public void Margin(int marginLeft, int marginTop, int marginRight, int marginBottom) => DockMargin(marginLeft, marginTop,  marginRight, marginBottom);

        /// <summary>
        /// Sets the left margin of the panel.
        /// Requires VoidUI.
        /// </summary>
        public void MarginLeft(int val)
        {
            VGUIPanel.MarginLeft(val);
        }
        
        /// <summary>
        /// Sets the right margin of the panel.
        /// Requires VoidUI.
        /// </summary>
        public void MarginRight(int val)
        {
            VGUIPanel.MarginRight(val);
        }
        
        /// <summary>
        /// Sets the top margin of the panel.
        /// Requires VoidUI.
        /// </summary>
        public void MarginTop(int val)
        {
            VGUIPanel.MarginTop(val);
        }
        
        /// <summary>
        /// Sets the bottom margin of the panel.
        /// Requires VoidUI.
        /// </summary>
        public void MarginBottom(int val)
        {
            VGUIPanel.MarginBottom(val);
        }
        
        #endregion
    }
}