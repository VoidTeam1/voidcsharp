using System;

namespace VoidSharp
{
    public class Color
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int A { get; set; }

        public Color(int r, int g, int b, int a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
        
        public override string ToString()
        {
            return $"Color({R}, {G}, {B}, {A})";
        }

        /// <summary>
        /// Converts the lua color to a C# Color Object
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public static Color FromGmodColor(dynamic col)
        {
            return new Color(col.r, col.g, col.b, col.a);
        }

        /// <summary>
        /// Converts the C# Color object to a lua color
        /// </summary>
        /// <returns></returns>
        public object ToGmodColor()
        {
            object obj = null;
            /*
            [[
                obj = Color(this.R, this.G, this.B, this.A)
            ]]
            */
            return obj;
        }
        
        public static readonly Color Primary = new Color(35, 35, 35);
        public static readonly Color Background = new Color(20, 20, 20);
        public static readonly Color BackgroundTransparent = new Color(20, 20, 20, 127);
        public static readonly Color InputDark = new Color(35, 35, 35);
        public static readonly Color InputLight = new Color(50, 50, 50);
        public static readonly Color Green = new Color(66, 170, 70);
        public static readonly Color LightGray = new Color(126, 126, 126);
        public static readonly Color Gray = new Color(222, 222, 222);
        public static readonly Color GrayTransparent = new Color(222, 222, 222, 120);
        public static readonly Color GrayText = new Color(110,110,110);
        public static readonly Color DarkGrayTransparent = new Color(52,52,52,200);
        public static readonly Color GrayDarker = new Color(170, 170, 170);
        public static readonly Color GrayOverlay = new Color(35, 35, 35, 220);
        public static readonly Color White = new Color(255,255,255);
        public static readonly Color WhiteOff = new Color(126, 126, 126);
        public static readonly Color GreenTransparent = new Color(66, 170, 70, 220);
        public static readonly Color Hover = new Color(45,45,45);
        public static readonly Color Black = new Color(0,0,0);
        public static readonly Color TextGray = new Color(77,77,77);
        public static readonly Color Red = new Color(170, 66, 66);
        public static readonly Color Blue = new Color(66, 104, 170);
        public static readonly Color Orange = new Color(170, 91, 66);
        public static readonly Color BlueGradientStart = new Color(66, 104, 170);
        public static readonly Color BlueGradientEnd = new Color(38, 60, 97);
        public static readonly Color BlueLineGradientEnd = new Color(33, 52, 85);
        public static readonly Color GreenGradientEnd = new Color(33, 85, 35);
        public static readonly Color Bronze = new Color(168, 106, 65);
        public static readonly Color Gold = new Color(210, 153, 38);
        public static readonly Color Silver = new Color(222, 222, 222);
    }
}
