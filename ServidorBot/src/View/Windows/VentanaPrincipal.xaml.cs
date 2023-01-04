using bot;
using Discord.WebSocket;
using ServidorBot.src.View.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ServidorBot.src.Datos;
using System.Collections.ObjectModel;
using ServidorBot.src.View.ControlsModificados;
using ServidorBot.src.View.UserControls;
using ServidorBot.src.View.Pages;

namespace ServidorBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ModeloVentanaPrincipal _modeloVentanaPrincipal;

        public MainWindow()
        {
            _modeloVentanaPrincipal = new ModeloVentanaPrincipal()
            {
                BarraPrincipal = new ModelBarraPrincipal()
                {
                    Title = Labels.NickWindowsMain,
                    ViewWindow = this
                },
            };

            llamada_bot();

            InitializeComponent();
            this.Visibility = Visibility.Hidden;

            crearVentana();


            DataContext = _modeloVentanaPrincipal;
        }

        private async void llamada_bot()
        {
            await _modeloVentanaPrincipal.Bot.MainAsyn();

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
                    CheckBoxSVChannel temp = new CheckBoxSVChannel(guild);
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
                    temp.Checked += (object sender, RoutedEventArgs e) =>
                    {
                        frame.Navigate(new SeccionDiscordEventos(temp._guild));
                    };

                    _modeloVentanaPrincipal.ListaServidores.Add(temp);


                    frame.Navigate(new SeccionMensaje());

                }
                this.Visibility = Visibility.Visible;

            });



        }

        private void Temp_Checked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine();
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

        private void Buttons_Click(object sender, RoutedEventArgs e)
        {
            var a = new Uri(Labels.UrlPage);
            if (frame.Source != a) frame.Source = a;
        }

        //------------------------





    }
}
