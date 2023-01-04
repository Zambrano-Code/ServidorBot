using Discord.WebSocket;
using ServidorBot.src.View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace ServidorBot.src.View.Pages
{
    /// <summary>
    /// Lógica de interacción para SeccionDiscordEventos.xaml
    /// </summary>
    public partial class SeccionDiscordEventos : Page
    {
        public SeccionDiscordEventos(SocketGuild guild)
        {
            InitializeComponent();

            DataContext = guild;
        }
    }
}
