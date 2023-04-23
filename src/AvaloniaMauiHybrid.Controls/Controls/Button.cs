using Avalonia.Maui.Extensions;
using AButton = Avalonia.Controls.Button;

namespace Avalonia.Maui.Controls
{
    public class Button : AvaloniaView, IDisposable
    {
        readonly AButton _button;

        public Button()
        {
            Content = _button = new AButton();

            _button.Click += OnButtonClick;
        }

        public void Dispose()
        {
            if (_button is not null)
            {
                _button.Click += OnButtonClick;
            }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(Button), string.Empty,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as Button).UpdateText();
                });

        public static new readonly BindableProperty BackgroundProperty =
            BindableProperty.Create(nameof(Background), typeof(Brush), typeof(Button), null, 
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as Button).UpdateBackground();
                }); 
        
        public static readonly BindableProperty ForegroundProperty = 
            BindableProperty.Create(nameof(Foreground), typeof(Brush), typeof(Button), null,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as Button).UpdateForeground();
                });

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(Button), 12d,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as Button).UpdateFontSize();
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

        public event EventHandler Click;

        void UpdateText()
        {
            _button.Content = Text;
        }

        void UpdateBackground()
        {
            _button.Background = Background.ToPlatform();
        }

        void UpdateForeground()
        {
            _button.Foreground = Foreground.ToPlatform();
        }

        void UpdateFontSize()
        {
            _button.FontSize = FontSize;
        }
        
        void OnButtonClick(object sender, Interactivity.RoutedEventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }
}