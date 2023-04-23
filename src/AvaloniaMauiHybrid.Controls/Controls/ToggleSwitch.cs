using AToggleSwitch = Avalonia.Controls.ToggleSwitch;

namespace Avalonia.Maui.Controls
{
    public class ToggleSwitch : AvaloniaView, IDisposable
    {
        readonly AToggleSwitch _toggleSwitch;

        public ToggleSwitch()
        {
            Content = _toggleSwitch = new AToggleSwitch();
        }

        public void Dispose()
        {
        }

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(CheckBox), false,
                propertyChanged: (bindableObject, oldValue, newValue) =>
             {
                 (bindableObject as ToggleSwitch).UpdateIsChecked();
             });

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        void UpdateIsChecked()
        {
            _toggleSwitch.IsChecked = IsChecked;
        }
    }
}