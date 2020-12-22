namespace VoidSharp.VoidUI
{
    public class Grid : Panel
    {
        public Grid() : base("VoidUI.Grid")
        {
        }

        public int HorizontalMargin
        {
            get => VGUIPanel.GetHorizontalMargin;
            set => VGUIPanel.SetHorizontalMargin(value);
        }
        
        public int VerticalMargin
        {
            get => VGUIPanel.GetVerticalMargin;
            set => VGUIPanel.SetVerticalMargin(value);
        }

        public void AddCell(Panel panel, bool fixedWidth = false, bool fixedHeight = false)
        {
            VGUIPanel.AddCell(panel, fixedWidth, fixedHeight);
        }

        public void AutoSize()
        {
            VGUIPanel.AutoSize();
        }

        public void Skip()
        {
            VGUIPanel.Skip();
        }

        public void Clear()
        {
            VGUIPanel.Clear();
        }
    }
}