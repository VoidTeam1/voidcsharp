﻿using System;

namespace VoidSharp.VoidUI
{
    public class Frame : Panel
    {
        public Frame() : base("VoidUI.Frame")
        {
        }

        public void SetTitle(string description)
        {
            VGUIPanel.SetTitle(description);
        }
    }
}