using System;
using System.Windows;
using System.Windows.Controls;

namespace ServidorBot.src.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para DataTimePicker.xaml
    /// </summary>
    public partial class DataTimePicker : UserControl
    {
        public static readonly DependencyProperty DateTimeProperty = DependencyProperty.Register(nameof(DateTime),
                                                                                             typeof(DateTime),
                                                                                             typeof(DataTimePicker),
                                                                                             new PropertyMetadata(new DateTime(), DateTimeChanged));


        public static readonly DependencyProperty DateProperty = DependencyProperty.Register(nameof(Date),
                                                                                             typeof(DateTime),
                                                                                             typeof(DataTimePicker),
                                                                                             new PropertyMetadata(new DateTime(), DateChanged));


        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register(nameof(Time),
                                                                                             typeof(TimeSpan),
                                                                                             typeof(DataTimePicker),
                                                                                             new PropertyMetadata(TimeSpan.Zero, TimeChanged));

        public static readonly DependencyProperty TextEditableProperty = DependencyProperty.Register(nameof(TextEditable),
                                                                                             typeof(bool),
                                                                                             typeof(DataTimePicker),
                                                                                             new PropertyMetadata(false));

        public DateTime DateTime
        {
            get { return (DateTime)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }

        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set 
            {
                SetValue(TimeProperty, value);
            }
        }

        public bool TextEditable
        {
            get { return (bool)GetValue(TextEditableProperty); }
            set { SetValue(TextEditableProperty, value); }
        }


        public DataTimePicker()
        {
            InitializeComponent();

        }
        private static void DateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataTimePicker dataTimePicker)
            {
                DateTime newValue = (DateTime)e.NewValue;
                dataTimePicker.DateTime = newValue;

                var TempDate = new DateTime(newValue.Year, newValue.Month, newValue.Day);
                var TempTime = new TimeSpan(newValue.Hour, newValue.Minute, newValue.Second);

                dataTimePicker.Date = TempDate;
                dataTimePicker.Time = TempTime;
            }
        }

        private static void TimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataTimePicker dataTimePicker)
            {
                TimeSpan newValue = (TimeSpan)e.NewValue;
                dataTimePicker.Time = newValue;

                dataTimePicker.DateTime = new DateTime(dataTimePicker.DateTime.Year, dataTimePicker.DateTime.Month, dataTimePicker.DateTime.Day, newValue.Hours, newValue.Minutes, newValue.Seconds); 
            }
        }

        private static void DateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataTimePicker dataTimePicker)
            {
                DateTime newValue = (DateTime)e.NewValue;
                dataTimePicker.Date = newValue;
                

                dataTimePicker.DateTime = new DateTime(newValue.Year, newValue.Month, newValue.Day, dataTimePicker.DateTime.Hour, dataTimePicker.DateTime.Minute, dataTimePicker.DateTime.Second);
            }
        }


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            DateTime = new DateTime();
        }

        //private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var datePicker = (DatePicker)sender;
        //    if (datePicker.SelectedDate == null) return;

        //    DateTime dateTemp = datePicker.SelectedDate.Value;

        //    Date = new DateTime(dateTemp.Year, dateTemp.Month, dateTemp.Day, Date.Hour, Date.Minute, Date.Second); ;
        //}

        //private void PickTime_SelectTime(object sender, EventArgs e)
        //{
        //    Utilidades.PickTime pickTime = (Utilidades.PickTime)sender;
        //    TimeSpan time = pickTime.Time; 


        //    Date = new DateTime(Date.Year, Date.Month, Date.Day, time.Hours, time.Minutes, time.Seconds);

        //}
    }
}
