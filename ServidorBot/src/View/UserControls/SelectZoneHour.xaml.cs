using ServidorBot.src.View.Clases;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ServidorBot.src.View.UserControls
{

    public partial class SelectZoneHour : UserControl
    {

        public static readonly DependencyProperty SelectProperty = DependencyProperty.Register(nameof(Select),
                                                                                           typeof(bool),
                                                                                           typeof(SelectZoneHour),
                                                                                           new PropertyMetadata(false));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text),
                                                                                   typeof(string),
                                                                                   typeof(SelectZoneHour),
                                                                                   new PropertyMetadata(""));


        public bool Select
        {
            get => (bool)GetValue(SelectProperty);
            set => SetValue(SelectProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private Storyboard _storyboardEntrada;
        private Storyboard _storyboardSalida;

        public SelectZoneHour()
        {
            InitializeComponent();
            _storyboardEntrada = new Storyboard();
            _storyboardSalida = new Storyboard();

            System.Windows.Duration duracion = new System.Windows.Duration(TimeSpan.FromMilliseconds(150));

            ClasesDeAnimacionesForFrames.BorderTranslateX(16, 0, duracion, Circle, _storyboardEntrada);
            ClasesDeAnimacionesForFrames.BorderTranslateX(0, 16, duracion, Circle, _storyboardSalida);

        }

        private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            if (Select)
            {
                Select = false;


                _storyboardEntrada.Begin();
            }
            else
            {

                Select = true;


                _storyboardSalida.Begin();
            }
        }


    }
}
