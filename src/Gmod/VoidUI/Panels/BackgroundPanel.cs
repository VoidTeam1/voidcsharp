namespace VoidSharp.VoidUI
{
    public class BackgroundPanel : Panel
    {
        public BackgroundPanel() : base("VoidUI.BackgroundPanel")
        {
        }

        public void SetTitle(string title)
        {
            VGUIPanel.SetTitle(title);
        }

        public void SetFont(string font)
        {
            VGUIPanel.SetFont(font);
        }
    }
}