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

        public bool UpdateOnType
        {
            get => VGUIPanel.GetUpdateOnType();
            set => VGUIPanel.SetUpdateOnType(value);
        }

        public void OnValueChange(Action<dynamic, string> callback)
        {
            VGUIPanel.OnValueChange = callback;
        }
        
        
    }
}