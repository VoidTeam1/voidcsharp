namespace VoidSharp.VoidUI
{
    public class Tabs : Panel
    {
        public Tabs() : base("VoidUI.Tabs")
        {
        }

        public void SetAccentColor(Color color)
        {
            VGUIPanel.accentColor = color.ToGmodColor();
        }

        public void SetMoveSpeed(float speed)
        {
            VGUIPanel.animSpeed = speed;
        }

        public void AddTab(string text, Panel panel, int wide)
        {
            VGUIPanel.AddTab(text, panel.VGUIPanel, wide);
        }

        public void SelectTab(int index)
        {
            VGUIPanel.SelectTab(index);
        }
    }
}