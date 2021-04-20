using System;

namespace VoidSharp.Derma
{
    public class Button : Panel
    {
        public Button() : base("DButton")
        {
        }

        public void DoClick(Action callback)
        {
            VGUIPanel.DoClick = callback;
        }

        public string Font
        {
            get => VGUIPanel.GetFont();
            set => VGUIPanel.SetFont(value);
        }

        public string Text
        {
            get => VGUIPanel.GetText();
            set => VGUIPanel.SetText(value);
        }
    }
}