using ASlider = Avalonia.Controls.Slider;

namespace Avalonia.Maui.Controls
{
    public class Slider : AvaloniaView, IDisposable
    {
        readonly ASlider _slider;

        public Slider()
        {
            Content = _slider = new ASlider();
        }

        public void Dispose()
        {
        }

        public static readonly BindableProperty MinimumProperty =
            BindableProperty.Create(nameof(Minimum), typeof(double), typeof(Slider), 0d,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as Slider).UpdateMinimum();
                });

        public static readonly BindableProperty MaximumProperty =
            BindableProperty.Create(nameof(Maximum), typeof(double), typeof(Slider), 100d,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as Slider).UpdateMaximum();
                }); 
        
        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(double), typeof(Slider), 0d,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as Slider).UpdateValue();
                });

        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        void UpdateMinimum()
        {
            _slider.Minimum = Minimum;
        }

        void UpdateMaximum()
        {
            _slider.Maximum = Maximum;
        }

        void UpdateValue()
        {
            _slider.Value = Value;
        }
    }
}