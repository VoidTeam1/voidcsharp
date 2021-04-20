using System;

namespace VoidSharp.Derma
{
    public class TextEntry : Panel
    {
        public TextEntry() : base("DTextEntry")
        {
        }

        public string Value
        {
            get => VGUIPanel.GetValue();
            set => VGUIPanel.SetValue(value);
        }

        public bool Numeric
        {
            get => VGUIPanel.GetNumeric();
            set => VGUIPanel.SetNumeric(value);
        }

        public void OnValueChange(Action<string> callback)
        {
            VGUIPanel.OnValueChange = callback;
        }
    }
}