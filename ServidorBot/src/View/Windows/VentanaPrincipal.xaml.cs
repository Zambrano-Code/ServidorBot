using bot;
using bot.modelos;
using Discord;
using Discord.WebSocket;
using Microsoft.VisualBasic;
using ServidorBot.src.view.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
using System.Windows.Threading;
using System.Windows.Media;

namespace ServidorBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bot bot = new Bot();

        private List<CheckBox> listDm = new List<CheckBox>();
        public MainWindow()
        {
            llamada_bot();

            InitializeComponent();
            this.Visibility = Visibility.Hidden;

            crearVentana();
        }

        private async void llamada_bot()
        {
            await bot.MainAsyn();

        }


        //-------------------------

        private void crearVentana()
        {

            Bot._cliente.Ready += () =>
            {
                agregarServidores();

                return Task.CompletedTask;
            };


        }


        private void agregarServidores()
        {
            var guilds = Bot._cliente.Guilds;

            this.Dispatcher.Invoke(() =>
            {

                foreach (SocketGuild guild in guilds)
                {
                    Button temp = new Button();
                    temp.Style = (Style)this.FindResource("buttonDinamicServer00");
                    temp.Name = "bor";

                    if (String.IsNullOrEmpty(guild.IconUrl))
                    {

                        temp.Background = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString("#36393F"));

                        string[] text = guild.Name.Split(" ");
                        string textTemp = "";
                        foreach (string s in text)
                        {

                            textTemp += s.Substring(0, 1);
                        }

                        temp.Content = textTemp;


                    }
                    else
                    {

                        System.Windows.Controls.Image _image = new System.Windows.Controls.Image();
                        BitmapImage _bi = new BitmapImage();

                        _bi.BeginInit();
                        _bi.UriSource = new System.Uri(guild.IconUrl);
                        _bi.EndInit();

                        _image.Source = _bi;

                        //Convesion
                        ImageBrush img = new ImageBrush();

                        img.ImageSource = _bi;

                        temp.Background = img;
                    }

                    List_Servidores.Children.Add(temp);



                }
                this.Visibility = Visibility.Visible;

            });



        }

        

        


        private async Task Relog(TimeSpan time1, TimeSpan time2, Action evento)
        {
            var timer = new PeriodicTimer(time1);

            while (await timer.WaitForNextTickAsync())
            {
                evento();
                if (time2 > TimeSpan.Zero)
                {
                    await Relog(time2, TimeSpan.Zero, evento);
                }


            }
        }

        //------------------------

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Buttons_Click(object sender, RoutedEventArgs e)
        {
            

        }

        

    }
}
