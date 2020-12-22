namespace VoidSharp.VoidUI
{
    public class Dropdown : Panel
    {
        public Dropdown() : base("VoidUI.Dropdown")
        {
        }

        public void ChooseOption(string value, int index)
        {
            VGUIPanel.ChooseOption(value, index);
        }

        public void SetLight()
        {
            VGUIPanel.SetLight();
        }
    }
}