using Discord;
using ServidorBot.src.View.Clases;
using ServidorBot.src.View.ViewModel;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServidorBot.src.View.View
{
    /// <summary>
    /// Lógica de interacción para PanelMensajesUser.xaml
    /// </summary>
    public partial class PanelMensajesUser : UserControl
    {
        private ImageBrush PlaceHolder;

        public PanelMensajesUser()
        {
            PlaceHolder = MetodosDeAceso.GetImageLocal("../../../src/View/img/PlaceHolder.png");

            InitializeComponent();
        }

        private void txtBody_TextChanged(object sender, TextChangedEventArgs e)
        {
            var myTextBox = (TextBox)sender;

            if (myTextBox.Text == "")
            {
                // Use the brush to paint the button's background.
                myTextBox.Background = PlaceHolder;
            }
            else
            {
                // Delete background
                myTextBox.Background = null;
            }

        }

        private void Evento_messageSend(object sender, KeyEventArgs e)
        {
            var myTextBox = (TextBox)sender;
            PanelMensajesUserVM dt = (PanelMensajesUserVM)DataContext;


            //            dt.User.SendMessageAsync
            //SendMessageAsync
            if ((Keyboard.Modifiers == ModifierKeys.Shift) && (e.Key == Key.Enter))
            {
                var a = myTextBox.Text.Length;
                myTextBox.SelectionStart = a;
                return;
            }

            if (e.Key == Key.Enter)
            {
                e.Handled = true;

                string temp = myTextBox.Text.Replace("\n", "").Replace("\r", "");

                if (String.IsNullOrEmpty(temp) && dt.Model.Embeds.Count == 0) return;


                dt.EnviarMensajeCommand.Execute(null);
            }
        }

        private void Scroll_Loaded(object sender, RoutedEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToBottom();
        }
    }
}
