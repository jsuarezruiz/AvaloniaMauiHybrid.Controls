using Avalonia.Markup.Xaml;
using Application = Avalonia.Application;

namespace AvaloniaMauiHybrid.Controls.Gallery
{
    public class AvaloniaApp : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            base.OnFrameworkInitializationCompleted();
        }
    }
}