using System;

namespace VoidSharp
{
    
    public static class Surface
    {
        /// <summary>
        /// Set the color of any future shapes to be drawn.
        /// </summary>
        public static void SetDrawColor(Color color)
        {
            Globals.Surface.SetDrawColor(color.ToGmodColor());
        }

        /// <summary>
        /// Draws a solid rectangle on the screen.
        /// </summary>
        public static void DrawRect(int x, int y, int w, int h)
        {
            Globals.Surface.DrawRect(x, y, w, h);
        }

        /// <summary>
        /// Set the color of any future text to be drawn.
        /// </summary>
        public static void SetFontColor(Color color)
        {
            Globals.Surface.SetTextColor(color.ToGmodColor());
        }

        /// <summary>
        /// Set the current font to be used for text operations later.
        /// The fonts must first be created with surface.CreateFont or be one of the Default Fonts.
        /// </summary>
        public static void SetFont(string fontName)
        {
            Globals.Surface.SetFont(fontName);
        }

        /// <summary>
        /// Set the top-left position to draw any future text at.
        /// </summary>
        public static void SetTextPos(int x, int y)
        {
            Globals.Surface.SetTextPos(x, y);
        }

        /// <summary>
        /// Draw the specified text on the screen, using the previously set position, font and color.
        /// </summary>
        public static void DrawText(string text)
        {
            Globals.Surface.DrawText(text);
        }

    }
}
