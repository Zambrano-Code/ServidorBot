using Microsoft.Xaml.Behaviors;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ServidorBot.Dictionarys
{
    public partial class diseñosButtons
    {

        private static int SPEED = 5;
        private static int VALUE1 = 20;
        private static int VALUE2 = 50;

        private void border_salida(object sender, MouseEventArgs e)
        {
            Button boton = sender as Button;


            Border border = boton.Template.FindName("border_interno", boton) as Border;
            Console.WriteLine(border.CornerRadius.TopLeft);

            animatedCornerRadius(border, VALUE1, VALUE2, SPEED).Begin();

        }

        private void border_entrada(object sender, MouseEventArgs e)
        {
            Button boton = sender as Button;


            Border border = boton.Template.FindName("border_interno", boton) as Border;
            Console.WriteLine(border.CornerRadius.TopLeft);

            animatedCornerRadius(border, VALUE2, VALUE1, SPEED).Begin();

        }

        private Storyboard animatedCornerRadius(Border border, int To, int From, Double Speed, int SaltoFotrograma = 1)
        {
            var sb = new Storyboard();
            var anim = new ObjectAnimationUsingKeyFrames();

            int Diferencia = (From - To);

            int va = 1;

            if (Diferencia < 0) { Diferencia *= -1; va = -1; }

            for (double i = 1; i <= Diferencia; i++)
            {
                ObjectKeyFrame temp = new DiscreteObjectKeyFrame
                {
                    Value = new CornerRadius(To + (i * va)),
                    KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(Speed * i))
                };


                anim.KeyFrames.Add(temp);
            }

            sb.Children.Add(anim);

            Storyboard.SetTarget(anim, border);
            Storyboard.SetTargetProperty(anim, new PropertyPath("CornerRadius"));

            sb.Duration = new Duration(TimeSpan.FromSeconds((Diferencia * Speed) + 2));

            return sb;
        }
    }
}
