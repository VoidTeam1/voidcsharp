using System;

namespace VoidSharp.Derma
{
    public class ColorMixer : Panel
    {
        public ColorMixer() : base("DColorMixer")
        {
        }

        public Color Color
        {
            get
            {
                object gColor = VGUIPanel.GetColor();
                return Color.FromGmodColor(gColor);
            }
            set => VGUIPanel.SetColor(value.ToGmodColor());
        }

        public void ValueChanged(Action<dynamic, dynamic> callback)
        {
            VGUIPanel.ValueChanged = callback;
        }
    }
}