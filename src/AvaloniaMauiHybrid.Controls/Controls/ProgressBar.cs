using AProgressBar = Avalonia.Controls.ProgressBar;

namespace Avalonia.Maui.Controls
{
    public class ProgressBar : AvaloniaView
    {
        readonly AProgressBar _progressBar;

        public ProgressBar()
        {
            Content = _progressBar = new AProgressBar();
        }

        public static readonly BindableProperty IsIndeterminateProperty =
            BindableProperty.Create(nameof(IsIndeterminate), typeof(bool), typeof(ProgressBar), false,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as ProgressBar).UpdateIsIndeterminate();
                });

        public static readonly BindableProperty ShowProgressTextProperty =
            BindableProperty.Create(nameof(ShowProgressText), typeof(bool), typeof(ProgressBar), false,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as ProgressBar).UpdateShowProgressText();
                });

        public bool IsIndeterminate
        {
            get { return (bool)GetValue(IsIndeterminateProperty); }
            set { SetValue(IsIndeterminateProperty, value); }
        }

        public bool ShowProgressText
        {
            get { return (bool)GetValue(ShowProgressTextProperty); }
            set { SetValue(ShowProgressTextProperty, value); }
        }

        void UpdateIsIndeterminate()
        {
            _progressBar.IsIndeterminate = IsIndeterminate;
        }

        void UpdateShowProgressText()
        {
            _progressBar.ShowProgressText = ShowProgressText;
        }
    }
}