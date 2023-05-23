using System;
using System.Windows;
using System.Windows.Controls;

namespace ServidorBot.src.View.UserControls
{
    public partial class TimeStampPick : UserControl
    {

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text),
                                                                                             typeof(string),
                                                                                             typeof(TimeStampPick));

        public static readonly DependencyProperty DateTimeProperty = DependencyProperty.Register(nameof(DateTime),
                                                                                     typeof(DateTime),
                                                                                     typeof(TimeStampPick));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value) ; }
        }

        public DateTime DateTime
        {
            get { return (DateTime)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }


        public TimeStampPick()
        {
            InitializeComponent();

        }

    }
}
