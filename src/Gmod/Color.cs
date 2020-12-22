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
        
        public static readonly Color White = new Color(255,255,255);
        public static readonly Color Black = new Color(0,0,0);
        public static readonly Color Red = new Color(255,0,0);
        public static readonly Color Green = new Color(0,255,0);
        public static readonly Color Blue = new Color(0,0,255);
    }
}
