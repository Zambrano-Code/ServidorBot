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
    public class MensageRepetitive : MensageBase
    {
        public DateTime TimeActive { get; private set; }
        public TimeSpan TimeToRepeat { get; private set; }
        public string ZoneHour { get; private set; }
        public DateTime ScheduledTime { get { return evento.ScheduledTime; } }
        private EventoRepetitive evento { get; set; }

        public MensageRepetitive(string name, string mensage, List<EmbedBuilder> embeds, DateTime tiempo_envio, TimeSpan time_to_repeat, string zone_hour, SocketChannel canalEnvio, SocketGuild guild_envio, SocketUser user_create) 
            : base(name, mensage, embeds, canalEnvio, guild_envio, user_create)
        {
            
            this.TimeActive = tiempo_envio;
            this.TimeToRepeat = time_to_repeat;
            this.ZoneHour = zone_hour;

            this.evento = new EventoRepetitive(name, this.TimeActive, this.TimeToRepeat, zone_hour, base.ejecutarMensage);
        }
        public MensageRepetitive(string name, string mensage, List<EmbedBuilder> embeds, DateTime tiempo_envio, TimeSpan time_to_repeat, string zone_hour, SocketChannel canalEnvio, SocketGuild guild_envio, SocketUser user_create, DateTime date_create)
            : base(name, mensage, embeds, canalEnvio, guild_envio, user_create, date_create)
        {

            this.TimeActive = tiempo_envio;
            this.TimeToRepeat = time_to_repeat;
            this.ZoneHour = zone_hour;

            this.evento = new EventoRepetitive(name, this.TimeActive, this.TimeToRepeat, zone_hour, base.ejecutarMensage);
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

