namespace VoidSharp.VoidUI
{
    public class Sidebar : Panel
    {
        public Sidebar() : base("VoidUI.Sidebar")
        {
        }

        public void SetAccentColor(Color color)
        {
            VGUIPanel.SetAccentColor(color.ToGmodColor());
        }

        public void SetFadeSpeed(float speed)
        {
            VGUIPanel.SetFadeSpeed(speed);
        }

        public void SetActive(bool active)
        {
            VGUIPanel.SetActive(active);
        }

        public void SelectTab(Panel tab)
        {
            VGUIPanel.SelectTab(tab.VGUIPanel);
        }

        public void SwitchTab(Panel tab, Panel panel)
        {
            VGUIPanel.SwitchTab(tab.VGUIPanel, panel.VGUIPanel);
        }

        public void AddTab(string text, string icon, Panel panel, bool bottomAlign, int[] iconSize)
        {
            VGUIPanel.AddTab(text, icon, panel.VGUIPanel, bottomAlign, iconSize);
        }
    }
}