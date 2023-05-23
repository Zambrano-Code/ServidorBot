using bot;
using bot.acciones;
using Discord;
using ServidorBot.src.View.Clases;
using ServidorBot.src.View.UserControls;
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

namespace ServidorBot.src.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para ModeloMensaje.xaml
    /// </summary>
    public partial class ModeloMensaje : UserControl
    {


        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(nameof(Message),
                                                                                           typeof(IMessage),
                                                                                           typeof(ModeloMensaje),
                                                                                           new PropertyMetadata(null));

        public IMessage Message
        {
            get { return (IMessage)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public ModeloMensaje()
        {
            InitializeComponent();

        }

    }
}
