namespace VoidSharp.VoidUI
{
    public class ElementGrid : Panel
    {
        public ElementGrid() : base("VoidUI.ElementGrid")
        {
        }

        public void AddElement(string title, string element, int height, bool noCell)
        {
            VGUIPanel.AddElement(title, element, height, noCell);
        }
    }
}