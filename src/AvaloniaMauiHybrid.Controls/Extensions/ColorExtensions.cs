namespace Avalonia.Maui.Extensions
{
    public static class ColorExtensions
    {
        public static Media.Color ToPlatform(this Color color)
        {
            color.ToRgba(out byte r, out byte g, out byte b, out byte a);

            return new Media.Color(a, r, g, b);
        }
    }
}