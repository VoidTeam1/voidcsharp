namespace VoidSharp.Derma
{
    public class Frame : Panel
    {
        public Frame() : base("DFrame")
        {
        }

        public string Title
        {
            get => VGUIPanel.GetTitle();
            set => VGUIPanel.SetTitle(value);
        }
        
        public void Close() => VGUIPanel.Close();
    }
}