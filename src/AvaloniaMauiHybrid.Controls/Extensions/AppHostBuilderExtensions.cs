using Avalonia.Maui.Controls;
using Avalonia.Maui.Handlers;

namespace Avalonia.Maui.Extensions
{
    public static class AppHostBuilderExtensions
    {
        public static MauiAppBuilder UseAvaloniaMauiHybridControls<TApp>(this MauiAppBuilder builder) where TApp : Application, new()
        {
            builder.UseAvalonia<TApp>(appBuilder =>
            {
            });

            builder.ConfigureMauiHandlers(handlers =>
            {
#if ANDROID || IOS
                handlers.AddHandler(typeof(AvaloniaView), typeof(AvaloniaViewHandler));
#endif
            });

            return builder;
        }
    }
}
