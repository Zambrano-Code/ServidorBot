using ServidorBot.src.View.Clases;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ServidorBot.src.View.UserControls
{
    public partial class PickTimeStamp : UserControl
    {
        public static readonly DependencyProperty NameElmentProperty = DependencyProperty.Register(nameof(NameElment),
                                                                                            typeof(string),
                                                                                            typeof(PickTimeStamp));


        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register(nameof(Time),
                                                                                            typeof(TimeSpan),
                                                                                            typeof(PickTimeStamp),
                                                                                            new PropertyMetadata(TimeSpan.Zero, TimeChanged));

        public static readonly DependencyProperty TimeFormatProperty = DependencyProperty.Register(nameof(TimeFormat),
                                                                                            typeof(string),
                                                                                            typeof(PickTimeStamp),
                                                                                            new PropertyMetadata("0:0:0"));


        public string NameElment
        {
            get { return (string)GetValue(NameElmentProperty); }
            set { SetValue(NameElmentProperty, value); }
        }

        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public string TimeFormat
        {
            get { return (string)GetValue(TimeFormatProperty); }
            set { SetValue(TimeFormatProperty, value); }
        }

        public PickTimeStamp()
        {
            InitializeComponent();
        }

        private static void TimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is PickTimeStamp pickTime)
            {
                var newTime = (TimeSpan)e.NewValue;

                pickTime.Time = newTime;
                pickTime.TimeFormat = MetodosDeAceso.FormatTimeSpan(newTime);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Time = TimeSpan.Zero;
        }
    }
}
