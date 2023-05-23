using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace ServidorBot.src.View.Clases
{
    public class ClasesDeAnimacionesForFrames
    {
        public static ObjectAnimationUsingKeyFrames animateGiro(double To, double From, double Speed, double SaltoFotrograma = 1)
        {
            var anim = new ObjectAnimationUsingKeyFrames();

            double Diferencia = (From - To);

            double va = 1;

            if (Diferencia < 0) { Diferencia *= -1; va = -1; }

            for (double i = 1; i <= Diferencia; i += SaltoFotrograma)
            {
                //    < Button.RenderTransform >
                //    < TransformGroup >
                //        < ScaleTransform />
                //        < SkewTransform />
                //        < RotateTransform Angle = "45" />
                //        < TranslateTransform />
                //    </ TransformGroup >
                //</ Button.RenderTransform >

                RotateTransform myRotateTransform = new RotateTransform();
                myRotateTransform.Angle = To + (i * va);

                TransformGroup myTransformGroup = new TransformGroup();
                myTransformGroup.Children.Add(myRotateTransform);


                ObjectKeyFrame temp = new DiscreteObjectKeyFrame
                {
                    Value = myTransformGroup,
                    KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(Speed * i))
                };

                //Console.WriteLine($"CorneRadius: {To + (i*va) }, KeyTime: {TimeSpan.FromMilliseconds(Speed * i).ToString()}");

                anim.KeyFrames.Add(temp);
            }

            return anim;
        }

        public static Storyboard BorderCornerRadius(double From, double To, Duration duration, Border border, Storyboard sb)
        {
            var anim = new ObjectAnimationUsingKeyFrames();

            double Diferencia = (To - From);

            double va = 1;

            double time = duration.TimeSpan.TotalMilliseconds / Diferencia;
            if (time < 0) { time *= -1; }

            if (Diferencia < 0) { Diferencia *= -1; va = -1; }

            for (double i = 1; i <= Diferencia; i++)
            {
                ObjectKeyFrame temp = new DiscreteObjectKeyFrame
                {
                    Value = new CornerRadius(From + (i * va)),
                    KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(time * i))
                };

                //Console.WriteLine($"CorneRadius: {From + (i*va) }, KeyTime: {TimeSpan.FromMilliseconds(time * i)}");

                anim.KeyFrames.Add(temp);
            }


            sb.Children.Add(anim);
            Storyboard.SetTarget(anim, border);
            Storyboard.SetTargetProperty(anim, new PropertyPath("CornerRadius"));

            return sb;
        }

        public static Storyboard BorderTranslateX(double fromX, double toX, Duration duration, Border border, Storyboard sb)
        {

            var animButtonWidth = new DoubleAnimation(fromX, toX, duration);

            sb.Children.Add(animButtonWidth);
            Storyboard.SetTarget(animButtonWidth, border);
            Storyboard.SetTargetProperty(animButtonWidth, new PropertyPath("RenderTransform.(TranslateTransform.X)"));

            return sb;
        }

        public static Storyboard BorderSizeXY(double fromX, double toX, double fromY, double toY, Duration duration, Border border, Storyboard sb)
        {
            BorderSizeX(fromX, toX, duration, border, sb);
            BorderSizeY(fromY, toY, duration, border, sb);


            return sb;
        }

        public static Storyboard BorderSizeX(double fromX, double toX, Duration duration, Border border, Storyboard sb)
        {
            var animButtonX = new DoubleAnimation(fromX, toX, duration);

            sb.Children.Add(animButtonX);
            Storyboard.SetTarget(animButtonX, border);
            Storyboard.SetTargetProperty(animButtonX, new PropertyPath("(Border.Width)"));

            return sb;
        }

        public static Storyboard BorderSizeY(double fromY, double toY, Duration duration, Border border, Storyboard sb)
        {
            var animButtonY = new DoubleAnimation(fromY, toY, duration);

            sb.Children.Add(animButtonY);
            Storyboard.SetTarget(animButtonY, border);
            Storyboard.SetTargetProperty(animButtonY, new PropertyPath("(Border.Height)"));

            return sb;
        }

        public static Storyboard TextBockColor(Color fromY, Color toY, Duration duration, TextBlock tb, Storyboard sb)
        {
            var animacion = new ColorAnimation(fromY, toY, duration);

            sb.Children.Add(animacion);
            Storyboard.SetTarget(animacion, tb);
            Storyboard.SetTargetProperty(animacion, new PropertyPath("(TextBlock.Foreground).(SolidColorBrush.Color)"));

            return sb;
        }
    }
}
