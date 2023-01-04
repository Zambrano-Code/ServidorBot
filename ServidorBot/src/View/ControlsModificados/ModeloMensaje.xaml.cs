using bot;
using bot.acciones;
using Discord;
using ServidorBot.src.View.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Reactive.Linq;
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

namespace ServidorBot.src.View.ControlsModificados
{
    /// <summary>
    /// Lógica de interacción para ModeloMensaje.xaml
    /// </summary>
    public partial class ModeloMensaje : UserControl
    {

        private IMensajeUser dat = new IMensajeUser();

        public ModeloMensaje(IMessage mensaje)
        {
            InitializeComponent();

            dat.Nombre = mensaje.Author.Username;
            dat.Fecha = mensaje.Timestamp.ToLocalTime().ToString("dddd, dd/MM/yyyy HH:mm:ss");
            dat.Mensaje = mensaje.Content;
            dat.Icon = getImg(mensaje.Author.GetAvatarUrl(), "../../../src/View/img/IconUser.png");

            var a = mensaje.Embeds.ToList();
            if (a.Count != 0) dat.Embeds = $"El mensaje tiene {a.Count} embeds, y no se puede visualizar";

            this.Dispatcher.Invoke(async () =>
            {

                foreach (var a in mensaje.Attachments)
                {
                    var btn = new Border()
                    {
                        Background = getImg(a.Url),
                        Width = a.Width.Value,
                        Height = a.Height.Value,
                        MaxWidth = 700,
                        MaxHeight = 500,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(10,10,0,0)
                    };

                    btn.MouseRightButtonUp += (object sender, MouseButtonEventArgs e) =>
                    {
                        Process.Start(new ProcessStartInfo { FileName = a.Url, UseShellExecute = true });
                    };
                    dat.Img.Add(btn);
                }

            });

            this.DataContext = dat;

            //Console.WriteLine($"Nombre: {dat.Nombre}, Fecha: {dat.Fecha}, Mensaje: {dat.Mensaje}");

        }


        private ImageBrush getImg(string url, string defaul)
        {

            //Console.WriteLine("cadena URL: " + url);
            if (!string.IsNullOrEmpty(url))
            {
                return getImg(url);
            }
            else
            {
                return getImg(defaul, null);
            }

        }

        private ImageBrush getImg(string url)
        {
            ImageBrush img = new ImageBrush(); ;
            //Console.WriteLine("cadena URL: " + url);
            try
            {
                img.ImageSource =
                new BitmapImage(
                    new Uri(url, UriKind.Relative)
                );
            }
            catch
            {
                System.Windows.Controls.Image _image = new System.Windows.Controls.Image();
                BitmapImage _bi = new BitmapImage();

                _bi.BeginInit();
                _bi.UriSource = new System.Uri(url);
                _bi.EndInit();

                _image.Source = _bi;


                img.ImageSource = _bi;
            }
            return img;

        }
    }
}
