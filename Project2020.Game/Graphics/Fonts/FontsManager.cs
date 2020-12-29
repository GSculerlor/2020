using osu.Framework.Graphics.Sprites;

namespace Project2020.Game.Graphics.Fonts
{
    public static class FontsManager
    {
        public const float DEFAULT_SIZE = 24;

        public static FontUsage GetFont(float size = DEFAULT_SIZE, FontWeight weight = FontWeight.Regular, bool italics = false, bool fixedWidth = false)
            => new FontUsage("Raleway", size, weight.ToString(), false, fixedWidth);
    
    }

    public enum FontWeight
    {
        Light = 300,

        Regular = 400,

        Medium = 500,

        SemiBold = 600,

        Bold = 700,

        Black = 900
    }
}