using Avalonia.Maui.Extensions;
using ATextBlock = Avalonia.Controls.TextBlock;

namespace Avalonia.Maui.Controls
{
    public class TextBlock : AvaloniaView, IDisposable
    {
        readonly ATextBlock _textBlock;

        public TextBlock()
        {
            Content = _textBlock = new ATextBlock();
        }

        public void Dispose()
        {
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(TextBlock), string.Empty,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as TextBlock).UpdateText();
                });

        public static new readonly BindableProperty BackgroundProperty =
            BindableProperty.Create(nameof(Background), typeof(Brush), typeof(TextBlock), null,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as TextBlock).UpdateBackground();
                });

        public static readonly BindableProperty ForegroundProperty =
            BindableProperty.Create(nameof(Foreground), typeof(Brush), typeof(TextBlock), null,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as TextBlock).UpdateForeground();
                });

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(TextBlock), 12d,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as TextBlock).UpdateFontSize();
                });

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        void UpdateText()
        {
            _textBlock.Text = Text;
        }

        void UpdateBackground()
        {
            _textBlock.Background = Background.ToPlatform();
        }

        void UpdateForeground()
        {
            _textBlock.Foreground = Foreground.ToPlatform();
        }

        void UpdateFontSize()
        {
            _textBlock.FontSize = FontSize;
        }
    }
}