using System;

namespace VoidSharp.VoidUI
{
    public class TextInput : Panel
    {
        public TextInput() : base("VoidUI.TextInput")
        {
        }

        public string Value
        {
            get => VGUIPanel.entry.GetValue();
            set => VGUIPanel.entry.SetColor(value);
        }

        public void SetFont(string font)
        {
            VGUIPanel.SetFont(font);
        }

        public void SetNumeric(bool b)
        {
            VGUIPanel.SetNumeric(b);
        }

        public void OnValueChange(Action<string> action)
        {
            VGUIPanel.OnValueChange = action;
        }
    }
}