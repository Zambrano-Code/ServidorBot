using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;

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

        public static ObjectAnimationUsingKeyFrames animatedCornerRadius(double To, double From, double Speed, double SaltoFotrograma = 1)
        {
            var anim = new ObjectAnimationUsingKeyFrames();

            double Diferencia = (From - To);

            double va = 1;

            if (Diferencia < 0) { Diferencia *= -1; va = -1; }

            for (double i = 1; i <= Diferencia; i += SaltoFotrograma)
            {
                ObjectKeyFrame temp = new DiscreteObjectKeyFrame
                {
                    Value = new CornerRadius(To + (i * va)),
                    KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(Speed * i))
                };

                //Console.WriteLine($"CorneRadius: {To + (i*va) }, KeyTime: {TimeSpan.FromMilliseconds(Speed * i).ToString()}");

                anim.KeyFrames.Add(temp);
            }

            return anim;
        }
    }
}
