using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using bot.acciones;
using bot.funciones;
using Discord.WebSocket;
using Discord;

namespace bot.acciones
{
    public class MensageRepetitive : Mensage
    {
        public DateTime tiempoEnvio { get; private set; }
        public TimeSpan timeToRepeat { get; private set; }
        public string zoneHour { get; private set; }
        private EventoRepetitive evento { get; set; }

        public MensageRepetitive(string name, string mensage, EmbedBuilder embed, DateTime tiempoEnvio, TimeSpan timeToRepeat, string zoneHour, SocketChannel canalEnvio) 
            : base(name, mensage, embed, canalEnvio)
        {
            
            this.tiempoEnvio = tiempoEnvio;
            this.timeToRepeat = timeToRepeat;
            this.zoneHour = zoneHour;

            this.evento = new EventoRepetitive(name, this.tiempoEnvio, this.timeToRepeat, zoneHour, ejecutarMensage);
        }

        private bool active = false;
        public bool Active { get { return active; } }
        public void Star()
        {
            if (!active)
            {
                evento.Run();
                active = true;
            }
        }
        public void Stop()
        {
            if (active)
            {
                evento.Stop();
                active = false;
            }
        }


        public string getName() { return evento.name; }


    }
}

