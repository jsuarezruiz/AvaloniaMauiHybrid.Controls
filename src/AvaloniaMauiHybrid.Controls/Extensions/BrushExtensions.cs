using Avalonia.Media;

namespace Avalonia.Maui.Extensions
{
    public static class BrushExtensions
    {
        public static IBrush ToPlatform(this Microsoft.Maui.Controls.Brush brush)
        {
            if(brush is Microsoft.Maui.Controls.SolidColorBrush solidColorBrush)
            {
                return new Media.SolidColorBrush(solidColorBrush.Color.ToPlatform());
            }

            return null;
        }
    }
}
