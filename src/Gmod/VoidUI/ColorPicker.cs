namespace VoidSharp.VoidUI
{
    public class ColorPicker : Panel
    {
        public ColorPicker() : base("VoidUI.ColorMixer")
        {
        }

        public Color Color
        {
            get => VoidSharp.Color.FromGmodColor(VGUIPanel.colorMixer.GetColor());
            set => VGUIPanel.colorMixer.SetColor(value.ToGmodColor());
        }
    }
}