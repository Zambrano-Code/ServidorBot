using Discord.WebSocket;
using ServidorBot.src.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.View.ViewModel
{
    public class SeccionDiscordEventosVM : ViewModelBase
    {

        public SeccionDiscordEventosM Model { get; set; }

        public SeccionDiscordEventosVM()
        {
            this.Model = new SeccionDiscordEventosM();
        }

        public SeccionDiscordEventosVM(SocketGuild guild)
        {
            this.Model = new SeccionDiscordEventosM();
        }
    }
}
