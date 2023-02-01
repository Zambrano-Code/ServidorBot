using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using bot.acciones;
using bot.funciones;
using Discord.WebSocket;
using Discord;
using ServidorBot.src.View.Clases;

namespace bot.acciones
{
    public class Mensage
    {
        public string name { get; private set; }
        public string mensage { get; private set; }
        public List<EmbedBuilder> embeds { get; private set; }
        public SocketGuild guild_envio { get; private set; }
        public SocketChannel canal_envio { get; private set; }
        public SocketUser user_create { get; private set; }
        public DateTime date_create { get; private set; }

        public Mensage()
        {

        }

        public Mensage(string name, string mensage, List<EmbedBuilder> embeds, SocketChannel canal_envio, SocketGuild guild_envio, SocketUser user_create)
        {

            this.name = name;
            this.mensage = mensage;
            this.embeds = embeds;
            this.guild_envio = guild_envio;
            this.canal_envio = canal_envio;
            this.user_create = user_create;
            this.date_create = DateTime.Now;
        }
        public Mensage(string name, string mensage, List<EmbedBuilder> embeds, SocketChannel canal_envio, SocketGuild guild_envio, SocketUser user_create, DateTime date_create)
        {

            this.name = name;
            this.mensage = mensage;
            this.embeds = embeds;
            this.guild_envio = guild_envio;
            this.canal_envio = canal_envio;
            this.user_create = user_create;
            this.date_create = date_create;
        }


        public async void ejecutarMensage()
        {

            IMessageChannel? canalEnvio2 = canal_envio as IMessageChannel;

            List<Embed> embed2 = new List<Embed>();
            foreach (EmbedBuilder embed in embeds)
            {
                embed2.Add(embed.Build());
            }

            await canalEnvio2.SendMessageAsync(text: mensage, embeds: embed2.ToArray());

        }

    }
}

