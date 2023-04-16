using ACalendar = Avalonia.Controls.Calendar;

namespace Avalonia.Maui.Controls
{
    public class Calendar : AvaloniaView
    {
        readonly ACalendar _calendar;

        public Calendar()
        {
            Content = _calendar = new ACalendar();
        }

        public static readonly BindableProperty FirstDayOfWeekProperty =
            BindableProperty.Create(nameof(FirstDayOfWeek), typeof(DayOfWeek), typeof(Calendar), null,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as Calendar).UpdateFirstDayOfWeek();
                }); 
        
        public static readonly BindableProperty IsTodayHighlightedProperty =
            BindableProperty.Create(nameof(IsTodayHighlighted), typeof(bool), typeof(Calendar), true,
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    (bindableObject as Calendar).UpdateIsTodayHighlighted();
                });

        public DayOfWeek FirstDayOfWeek
        {
            get { return (DayOfWeek)GetValue(FirstDayOfWeekProperty); }
            set { SetValue(FirstDayOfWeekProperty, value); }
        }

        public bool IsTodayHighlighted
        {
            get { return (bool)GetValue(IsTodayHighlightedProperty); }
            set { SetValue(IsTodayHighlightedProperty, value); }
        }

        void UpdateFirstDayOfWeek()
        {
            _calendar.FirstDayOfWeek = FirstDayOfWeek;
        }

        void UpdateIsTodayHighlighted()
        {
            _calendar.IsTodayHighlighted = IsTodayHighlighted;
        }
    }
}