using System.Windows;
using System.Windows.Controls;


namespace ServidorBot.src.View.UserControls
{
   
    public partial class TextBoxLimText : UserControl
    {

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text),
                                                                                             typeof(string),
                                                                                             typeof(TextBoxLimText),
                                                                                             new PropertyMetadata(""));

        public static readonly DependencyProperty NameElmentProperty = DependencyProperty.Register(nameof(NameElment),
                                                                                             typeof(string),
                                                                                             typeof(TextBoxLimText));

        public static readonly DependencyProperty LengthTextProperty = DependencyProperty.Register(nameof(LengthText),
                                                                                            typeof(int),
                                                                                            typeof(TextBoxLimText));

        public static readonly DependencyProperty VisibleCountProperty = DependencyProperty.Register(nameof(VisibleCount),
                                                                                           typeof(Visibility),
                                                                                           typeof(TextBoxLimText));

        public static readonly DependencyProperty ReturnProperty = DependencyProperty.Register(nameof(Return),
                                                                                          typeof(bool),
                                                                                          typeof(TextBoxLimText));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string NameElment
        {
            get { return (string)GetValue(NameElmentProperty); }
            set { SetValue(NameElmentProperty, value); }
        }

        public int LengthText
        {
            get { return (int)GetValue(LengthTextProperty); }
            set { SetValue(LengthTextProperty, value); }
        }

        public Visibility VisibleCount
        {
            get { return (Visibility)GetValue(VisibleCountProperty); }
            set { SetValue(VisibleCountProperty, value); }
        }

        public bool Return
        {
            get { return (bool)GetValue(ReturnProperty); }
            set { SetValue(ReturnProperty, value); }
        }

        public TextBoxLimText()
        {

            InitializeComponent();

        }
    }


}
