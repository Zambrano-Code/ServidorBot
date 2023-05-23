using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServidorBot.src.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para SelectColorTextBlock.xaml
    /// </summary>
    public partial class SelectColorTextBlock : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text),
                                                                                            typeof(string),
                                                                                            typeof(SelectColorTextBlock),
                                                                                            new PropertyMetadata("Color"));

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(nameof(Color),
                                                                                           typeof(Color),
                                                                                           typeof(SelectColorTextBlock),
                                                                                           new PropertyMetadata(Colors.White));


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public SelectColorTextBlock()
        {
            InitializeComponent();
        }
    }
}
