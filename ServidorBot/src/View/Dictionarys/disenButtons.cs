using bot;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Xaml.Behaviors;
using System;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using ServidorBot.src.View.Clases;

using Duration = System.Windows.Duration;

namespace ServidorBot.Dictionarys
{
    public partial class disenButtons
    {
        //-------------------------------------------------------
        private static double SPEED = 20;
        private static int VALUE1 = 18;
        private static double VALUE2 = 50 / 2;
        private static int SALTO_F = 1;


        //----------------------------------------------------

        private static double FromWidth = 0;
        private static double ToWidth = 5;

        private static double FromHeight = 0;
        private static double ToHeight = 20;

        private static double SelectElemenWidthP1 = 20;
        private static double SelectElemenWidthP2 = 40;
        //----------------------------------------------------

        private static Color Color1 = (Color)ColorConverter.ConvertFromString("#36393F");
        private static Color Color2 = (Color)ColorConverter.ConvertFromString("#5865F2");


        private static Duration _du = new Duration(TimeSpan.FromMilliseconds(150));

        private ObjectAnimationUsingKeyFrames animEntrada;
        private DoubleAnimation animEntradaBordeWidth;
        private DoubleAnimation animEntradaBordeHeight;
        private ColorAnimation animEntradaColor;

        private ObjectAnimationUsingKeyFrames animSalida;
        private DoubleAnimation animSalidaBordeWidth;
        private DoubleAnimation animSalidaBordeHeight;
        private ColorAnimation animaSalidaColor;

        private DoubleAnimation selectElementEntrada;
        private DoubleAnimation selectElementSalida;
        //----------------------------------------------------

        private CheckBox botonSelected;


        public disenButtons()
        {

            InitializeComponent();


            animEntrada = ClasesDeAnimacionesForFrames.animatedCornerRadius(VALUE2, VALUE1, SPEED, SALTO_F);
            animEntradaBordeWidth = new DoubleAnimation(FromWidth, ToWidth, _du);
            animEntradaBordeHeight = new DoubleAnimation(FromHeight, ToHeight, _du);
            animEntradaColor = new ColorAnimation(Color1, Color2, _du);

            animSalida = ClasesDeAnimacionesForFrames.animatedCornerRadius(VALUE1, VALUE2, SPEED, SALTO_F);
            animSalidaBordeWidth = new DoubleAnimation(ToWidth, FromWidth, _du);
            animSalidaBordeHeight = new DoubleAnimation(ToHeight, FromHeight, _du);
            animaSalidaColor = new ColorAnimation(Color2, Color1, _du);

            selectElementEntrada = new DoubleAnimation(SelectElemenWidthP1, SelectElemenWidthP2, _du);
            selectElementSalida = new DoubleAnimation(SelectElemenWidthP2, 0, _du);

        }
        private void border_salida(object sender, MouseEventArgs e)
        {

            var sb = new Storyboard();

            CheckBox boton = sender as CheckBox;

            Border border1 = boton.Template.FindName("border_interno", boton) as Border;
            Border border2 = boton.Template.FindName("border_animati", boton) as Border;


            var posi = e.GetPosition(border2);

            if (posi.X <= ToWidth)
            {
                return;
            }


            //-----------------------
            if (botonSelected != boton)
            {
                if (border1.Background.GetType().Name != "ImageBrush")
                {
                    sb.Children.Add(animaSalidaColor);
                    Storyboard.SetTarget(animaSalidaColor, border1);
                    Storyboard.SetTargetProperty(animaSalidaColor, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
                }

                sb.Children.Add(animSalida);
                Storyboard.SetTarget(animSalida, border1);
                Storyboard.SetTargetProperty(animSalida, new PropertyPath("CornerRadius"));

                sb.Children.Add(animSalidaBordeHeight);
                Storyboard.SetTarget(animSalidaBordeHeight, border2);
                Storyboard.SetTargetProperty(animSalidaBordeHeight, new PropertyPath("(Border.Height)"));

                sb.Children.Add(animSalidaBordeWidth);
                Storyboard.SetTarget(animSalidaBordeWidth, border2);
                Storyboard.SetTargetProperty(animSalidaBordeWidth, new PropertyPath("(Border.Width)"));
            }

            //----------------------------

            sb.Begin();

        }

        private void border_entrada(object sender, MouseEventArgs e)
        {
            var sb = new Storyboard();

            CheckBox boton = sender as CheckBox;

            Border border1 = boton.Template.FindName("border_interno", boton) as Border;
            Border border2 = boton.Template.FindName("border_animati", boton) as Border;

            var posi = e.GetPosition(border2);

            if (posi.X <= ToWidth)
            {
                return;
            }


            //-----------------------


            if (botonSelected != boton)
            {
                if (border1.Background.GetType().Name != "ImageBrush")
                {
                    sb.Children.Add(animEntradaColor);
                    Storyboard.SetTarget(animEntradaColor, border1);
                    Storyboard.SetTargetProperty(animEntradaColor, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
                }

                sb.Children.Add(animEntradaBordeHeight);
                Storyboard.SetTarget(animEntradaBordeHeight, border2);
                Storyboard.SetTargetProperty(animEntradaBordeHeight, new PropertyPath("(Border.Height)"));

                sb.Children.Add(animEntradaBordeWidth);
                Storyboard.SetTarget(animEntradaBordeWidth, border2);
                Storyboard.SetTargetProperty(animEntradaBordeWidth, new PropertyPath("(Border.Width)"));

                sb.Children.Add(animEntrada);
                Storyboard.SetTarget(animEntrada, border1);
                Storyboard.SetTargetProperty(animEntrada, new PropertyPath("CornerRadius"));
            }

            //----------------------------

            sb.Begin();

        }

        private void accion_click(object sender, RoutedEventArgs e)
        {
            var sb = new Storyboard();
            CheckBox botonPreset = sender as CheckBox;
            Border borderBP1 = botonPreset.Template.FindName("border_animati", botonPreset) as Border;

            if (botonSelected == botonPreset) return;
            if (botonSelected != null)
            {
                Border borderS1 = botonSelected.Template.FindName("border_interno", botonSelected) as Border;
                Border borderS2 = botonSelected.Template.FindName("border_animati", botonSelected) as Border;

                sb.Children.Add(selectElementSalida);
                Storyboard.SetTarget(selectElementSalida, borderS2);
                Storyboard.SetTargetProperty(selectElementSalida, new PropertyPath("(Border.Height)"));

                if (borderS1.Background.GetType().Name != "ImageBrush")
                {
                    sb.Children.Add(animaSalidaColor);
                    Storyboard.SetTarget(animaSalidaColor, borderS1);
                    Storyboard.SetTargetProperty(animaSalidaColor, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
                }

                sb.Children.Add(animSalida);
                Storyboard.SetTarget(animSalida, borderS1);
                Storyboard.SetTargetProperty(animSalida, new PropertyPath("CornerRadius"));

                sb.Children.Add(animSalidaBordeWidth);
                Storyboard.SetTarget(animSalidaBordeWidth, borderS2);
                Storyboard.SetTargetProperty(animSalidaBordeWidth, new PropertyPath("(Border.Width)"));

                botonSelected.IsChecked = false;
            }
            sb.Children.Add(selectElementEntrada);
            Storyboard.SetTarget(selectElementEntrada, borderBP1);
            Storyboard.SetTargetProperty(selectElementEntrada, new PropertyPath("(Border.Height)"));

            Thread.Sleep(150);
            botonPreset.IsChecked = true;
            botonSelected = botonPreset;
            sb.Begin();


        }




    }
}
