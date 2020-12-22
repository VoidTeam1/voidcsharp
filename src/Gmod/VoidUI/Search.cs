using System;

namespace VoidSharp.VoidUI
{
    public class Search : Panel
    {
        public Search() : base("VoidUI.Search")
        {
        }

        public void OnSearch(Action<string> action)
        {
            VGUIPanel.self.OnSearch = action;
        }
    }
}