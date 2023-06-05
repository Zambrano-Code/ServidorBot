using bot.acciones;
using Discord.WebSocket;
using ServidorBot.src.View.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.View.ViewModel
{
    public class SeccionDiscordEventosVM : ViewModelBase
    {

        public SeccionDiscordEventosM Model { get; set; } = new ();

        public ObservableCollection<MensageRepetitive> EventosDeMensajes { get; set; } = new();

        public SeccionDiscordEventosVM()
        {
        }

        public SeccionDiscordEventosVM(SocketGuild guild)
        {
            this.Model = new SeccionDiscordEventosM();
            Model.Guild = guild;

            run();
        }

        public void run()
        {
            if(Model.Guild != null)
            {
                EventosDeMensajes.Clear();
                var msgEvent = App.Bot.GetMensajeRepeatGuild(Model.Guild);

                foreach (var item in msgEvent)
                {
                    EventosDeMensajes.Add(item);
                }
            }
        } 
    }
}
