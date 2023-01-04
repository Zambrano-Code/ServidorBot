
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ServidorBot.src.View.Clases;

namespace ServidorBot.View.Dictionarys
{
    public partial class dicenElement
    {
        private ObjectAnimationUsingKeyFrames animEntrada;
        private ObjectAnimationUsingKeyFrames animSalida;

        #region Configuracion de animaciones
        private static int AngleInicial = 0;
        private static int AngleFinal = 45;
        private static int Speed = 3;
        #endregion



        public dicenElement()
        {
            animEntrada = ClasesDeAnimacionesForFrames.animateGiro(AngleInicial, AngleFinal, Speed);
            animSalida = ClasesDeAnimacionesForFrames.animateGiro(AngleFinal, AngleInicial, Speed);
        }

        public CheckBox checkBox { get; private set; }
        private void Botn_Click(object sender, RoutedEventArgs e)
        {
            var ck = (CheckBox)sender;

            if (checkBox == null) { checkBox = ck; }
            else if (checkBox == ck) { ck.IsChecked = true; }
            else if (checkBox != ck) { checkBox.IsChecked = false; checkBox = ck; }

            return;

        }

        private void Giro_Entrada(object sender, MouseEventArgs e)
        {

            var sb = new Storyboard();

            Button boton = sender as Button;

            Path border1 = boton.Template.FindName("Path", boton) as Path;


            //-----------------------
            sb.Children.Add(animEntrada);
            Storyboard.SetTarget(animEntrada, border1);
            Storyboard.SetTargetProperty(animEntrada, new PropertyPath("(Path.RenderTransform)"));

            sb.Begin();
            //----------------------------



        }

        private void Giro_salida(object sender, MouseEventArgs e)
        {

            var sb = new Storyboard();

            Button boton = sender as Button;

            Path border1 = boton.Template.FindName("Path", boton) as Path;


            //-----------------------
            sb.Children.Add(animSalida);
            Storyboard.SetTarget(animSalida, border1);
            Storyboard.SetTargetProperty(animSalida, new PropertyPath("(Path.RenderTransform)"));

            sb.Begin();
            //----------------------------



        }



    }
}
