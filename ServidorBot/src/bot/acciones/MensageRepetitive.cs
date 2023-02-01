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
        public DateTime tiempo_envio { get; private set; }
        public TimeSpan time_to_repeat { get; private set; }
        public string zone_hour { get; private set; }
        private EventoRepetitive evento { get; set; }

        public MensageRepetitive(string name, string mensage, List<EmbedBuilder> embeds, DateTime tiempo_envio, TimeSpan time_to_repeat, string zone_hour, SocketChannel canalEnvio, SocketGuild guild_envio, SocketUser user_create) 
            : base(name, mensage, embeds, canalEnvio, guild_envio, user_create)
        {
            
            this.tiempo_envio = tiempo_envio;
            this.time_to_repeat = time_to_repeat;
            this.zone_hour = zone_hour;

            this.evento = new EventoRepetitive(name, this.tiempo_envio, this.time_to_repeat, zone_hour, base.ejecutarMensage);
        }
        public MensageRepetitive(string name, string mensage, List<EmbedBuilder> embeds, DateTime tiempo_envio, TimeSpan time_to_repeat, string zone_hour, SocketChannel canalEnvio, SocketGuild guild_envio, SocketUser user_create, DateTime date_create)
            : base(name, mensage, embeds, canalEnvio, guild_envio, user_create, date_create)
        {

            this.tiempo_envio = tiempo_envio;
            this.time_to_repeat = time_to_repeat;
            this.zone_hour = zone_hour;

            this.evento = new EventoRepetitive(name, this.tiempo_envio, this.time_to_repeat, zone_hour, base.ejecutarMensage);
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

