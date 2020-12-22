using System;

namespace VoidSharp
{
    // ReSharper disable once InconsistentNaming
    public static class VGUI
    {
        /// <summary>
        /// Creates a panel by the specified classname.
        /// </summary>
        public static dynamic Create(string className, Panel parent = null, string name = null)
        {
            dynamic func = Globals.VGUI.Create;
            return func(className, parent, name);
        }
        
        /// <summary>
        /// Registers a panel for later creation.
        /// </summary>
        public static void Register(string className, object panelTable, string baseName = "Panel")
        {
            dynamic func = Globals.VGUI.Register;
            func(className, panelTable, baseName);
        }

        /// <summary>
        /// Creates a panel from table.
        /// </summary>
        public static dynamic CreateFromTable(dynamic metatable, Panel parent = null, string name = null)
        {
            dynamic func = Globals.VGUI.CreateFromTable;
            return func(metatable, parent, name);
        }

        /// <summary>
        /// Returns the global world panel which is the parent to all others, except for the HUD panel.
        /// </summary>
        public static dynamic GetWorldPanel()
        {
            return Globals.VGUI.GetWorldPanel();
        }
    }
}