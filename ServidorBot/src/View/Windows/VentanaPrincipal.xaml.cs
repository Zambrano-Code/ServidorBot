using bot;
using ServidorBot.src.view.UserControls;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServidorBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bot bot = new Bot();
        private Storyboard animacionBordeEntrada = new Storyboard();
        private Storyboard animacionBordeSalida = new Storyboard();

        public MainWindow()
        {
            llamada_bot();
            InitializeComponent();

            

        }

        private async void llamada_bot()
        {
            await bot.MainAsyn();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

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


        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        

        private void Grid_Cole_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
