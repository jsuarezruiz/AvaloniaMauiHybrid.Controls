using Avalonia.Maui.Extensions;
using ACheckBox = Avalonia.Controls.CheckBox;

namespace Avalonia.Maui.Controls
{
    public class CheckBox : AvaloniaView, IDisposable
    {
        readonly ACheckBox _checkbox;

        public CheckBox()
        {
            Content = _checkbox = new ACheckBox();

            _checkbox.Checked += OnCheckboxChecked;
            _checkbox.Unchecked += OnCheckboxUnchecked;
        }

        public void Dispose()
        {
            if(_checkbox is not null)
            {
                _checkbox.Checked += OnCheckboxChecked;
                _checkbox.Unchecked += OnCheckboxUnchecked;
            }
        }

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(CheckBox), false,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as CheckBox).UpdateIsChecked();
                });

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(CheckBox), string.Empty,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as CheckBox).UpdateText();
                });

        public static new readonly BindableProperty BackgroundProperty =
            BindableProperty.Create(nameof(Background), typeof(Brush), typeof(CheckBox), null,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as CheckBox).UpdateBackground();
                });

        public static readonly BindableProperty ForegroundProperty =
            BindableProperty.Create(nameof(Foreground), typeof(Brush), typeof(CheckBox), null,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as CheckBox).UpdateForeground();
                });

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(CheckBox), 12d,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as CheckBox).UpdateFontSize();
                });

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

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

        public event EventHandler Checked;
        public event EventHandler Unchecked;

        void UpdateIsChecked()
        {
            _checkbox.IsChecked = IsChecked;
        }

        void UpdateText()
        {
            _checkbox.Content = Text;
        }

        void UpdateBackground()
        {
            _checkbox.Background = Background.ToPlatform();
        }

        void UpdateForeground()
        {
            _checkbox.Foreground = Foreground.ToPlatform();
        }

        void UpdateFontSize()
        {
            _checkbox.FontSize = FontSize;
        }

        void OnCheckboxChecked(object sender, Interactivity.RoutedEventArgs e)
        {
            Checked?.Invoke(this, EventArgs.Empty);
        }

        void OnCheckboxUnchecked(object sender, Interactivity.RoutedEventArgs e)
        {
            Unchecked?.Invoke(this, EventArgs.Empty);
        }
    }
}