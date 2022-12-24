using bot;
using Discord;
using ServidorBot.src.View.ControlsModificados;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading;
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
using ServidorBot.src.View.Clases;
using ServidorBot.src.View.Windows;

namespace ServidorBot.src.View.Dictionarys
{
    /// <summary>
    /// Lógica de interacción para SeccionMensaje.xaml
    /// </summary>
    public partial class SeccionMensaje : Page
    {
        private Dictionary<UserStatus, string> estatus = new Dictionary<UserStatus, string>()
        {
            {UserStatus.Online, "#3BA55C"},
            {UserStatus.Offline, "#757E8A" }
        };
        private CheckBoxDMChannel userCheck;
        private createEmbed _cE = new createEmbed();
        public ObservableCollection<ModeloMensaje> _MUC { get; set; }


        public SeccionMensaje()
        {
            _MUC = new ObservableCollection<ModeloMensaje>();

            Bot._cliente.Ready += () =>
            {
                cargarUsers();
                return Task.CompletedTask;
            };

            Bot._cliente.MessageReceived += _cliente_MessageReceived;

            InitializeComponent();
        }


        private void cargarUsers()
        {
            this.Dispatcher.Invoke(async () =>
            {
                foreach (var item in Bot._chanelDMUser.Reverse())
                {
                    agregarUser(item);
                }
                Bot._chanelDMUser.CollectionChanged += _chanelDMUser_CollectionChanged;

            });

        }


        public void agregarUser(IDMChannel idm)
        {
            CheckBoxDMChannel botn = new CheckBoxDMChannel(idm);
            IUser user = botn._iDMChannel.Recipient;

            var url = user.GetAvatarUrl();

            if (!String.IsNullOrEmpty(url))
            {

                botn.Style = (Style)this.FindResource("CheckBoxSelectUser");

                System.Windows.Controls.Image _image = new System.Windows.Controls.Image();
                BitmapImage _bi = new BitmapImage();

                _bi.BeginInit();
                _bi.UriSource = new System.Uri(url);
                _bi.EndInit();

                _image.Source = _bi;

                //Convesion
                ImageBrush img = new ImageBrush();

                img.ImageSource = _bi;
                botn.Background = img;

            }
            else
            {
                botn.Style = (Style)this.FindResource("CheckBoxSelectUserIcon");
            }

            botn.Content = user.Username;
            botn.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(estatus[user.Status]));
            botn.Checked += accionForOptions;


            Colum_select.Children.Add(botn);
        }

        private async void cargarMensajes(int lim)
        {
            var messages = userCheck._iDMChannel.GetMessagesAsync(limit: lim);

            await foreach (var a in messages)
            {
                foreach (var b in a.Reverse())
                {
                    ModeloMensaje mensaje = new ModeloMensaje(b);

                    _MUC.Add(mensaje);
                }
                //Console.WriteLine("una vez");
            }

        }
        //--------------------- ACCIONES -----------------------
        private Task _cliente_MessageReceived(Discord.WebSocket.SocketMessage arg)
        {
            this.Dispatcher.Invoke(async () =>
            {
                if (userCheck == null) return;
                if (arg.Author.Id == userCheck._iDMChannel.Recipient.Id)
                {
                    var i = userCheck._iDMChannel.GetMessageAsync(arg.Id).Result;
                    //Console.WriteLine($"Nombre: {i.Author.Username} \n\tconten: {i.Content}\n\tcomponent: {i.Components.Count}\n\tsourse: {i.Source}\n\tflags: {i.Flags}\n\tAttachments: {i.Attachments.Count}");
                    ModeloMensaje ms = new ModeloMensaje(i);
                    _MUC.Add(ms);
                    scrview.ScrollToEnd();
                }
                //Console.WriteLine(arg.Author.Id + " " + userCheck._iDMChannel.Recipient.Id);
            });
            return Task.CompletedTask;

        }

        private void txtBody_TextChanged(object sender, TextChangedEventArgs e)
        {
            var myTextBox = sender as TextBox;

            if (myTextBox.Text == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri("../../../src/View/img/PlaceHolder.png", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                myTextBox.Background = textImageBrush;
            }
            else
            {

                myTextBox.Background = null;
            }

        }

        private void _chanelDMUser_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (IDMChannel item in e.NewItems)
            {
                Console.WriteLine(item.Name);
                this.Dispatcher.Invoke(async () =>
                {
                    agregarUser(item);
                });
            }


        }

        private void accionForOptions(object sender, RoutedEventArgs e)
        {

            CheckBoxDMChannel boxChecke = sender as CheckBoxDMChannel;

            if (boxChecke == userCheck) return;

            userCheck = boxChecke;

            _MUC.Clear();
            txtBody.IsEnabled = true;
            txtBody.Text = "";
            cargarMensajes(100);
            scrview.ScrollToEnd();
        }

        private void ScrollViewer_Initialized(object sender, EventArgs e)
        {
            scrview.ScrollToEnd();
        }

        private void evento_messageSend(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.Shift) && (e.Key == Key.Enter))
            {
                var a = txtBody.Text.Length;
                txtBody.SelectionStart = a;
                return;
            }

            if (e.Key == Key.Enter)
            {
                e.Handled = true;

                string temp = txtBody.Text.Replace("\n", "").Replace("\r", "");

                if (String.IsNullOrEmpty(temp)) return;

                //Console.WriteLine($"value: '{temp2}' leng: {temp2.Length}");
                var i2 = userCheck._iDMChannel.SendMessageAsync(txtBody.Text).Result;
                _MUC.Add(new ModeloMensaje(i2));
                txtBody.Text = "";
            }

        }

        private void button_CrearEmbed(object sender, RoutedEventArgs e)
        {
            _cE.getEmbed();

        }
    }
}
