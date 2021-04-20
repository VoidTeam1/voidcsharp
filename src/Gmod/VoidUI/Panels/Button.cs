namespace VoidSharp.VoidUI
{
    public class Button : Panel
    {
        public Button() : base("VoidUI.Button")
        {
        }

        public void SetColor(Color color)
        {
            VGUIPanel.SetColor(color.ToGmodColor());
        }

        public void SetColor(Color color, Color bgColor)
        {
            VGUIPanel.SetColor(color.ToGmodColor(), bgColor.ToGmodColor());
        }

        public void SetMedium()
        {
            VGUIPanel.SetMedium();
        }

        public void SetSmaller()
        {
            VGUIPanel.SetSmaller();
        }

        public void SetCompact()
        {
            VGUIPanel.SetCompact();
        }

        public void SetTextColor(Color color)
        {
            VGUIPanel.SetTextColor(color.ToGmodColor());
        }
    }
}