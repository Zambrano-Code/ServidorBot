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
    public class MensageBase
    {
        public string Name { get; private set; }
        public string Mensage { get; private set; }
        public List<EmbedBuilder> Embeds { get; private set; }
        public SocketGuild Guild { get; private set; }
        public SocketChannel Channel { get; private set; }
        public SocketUser CreateFor { get; private set; }
        public DateTime DateCreate { get; private set; }


        #region contrurtores
        public MensageBase()
        {

        }
        public MensageBase(string name, string mensage, List<EmbedBuilder> embeds, SocketChannel canal_envio, SocketGuild guild_envio, SocketUser user_create)
        {

            this.Name = name;
            this.Mensage = mensage;
            this.Embeds = embeds;
            this.Guild = guild_envio;
            this.Channel = canal_envio;
            this.CreateFor= user_create;
            this.DateCreate = DateTime.Now;
        }
        public MensageBase(string name, string mensage, List<EmbedBuilder> embeds, SocketChannel canal_envio, SocketGuild guild_envio, SocketUser user_create, DateTime date_create)
        {

            this.Name = name;
            this.Mensage = mensage;
            this.Embeds = embeds;
            this.Guild = guild_envio;
            this.Channel = canal_envio;
            this.CreateFor = user_create;
            this.DateCreate = date_create;
        }
        #endregion

        public async void ejecutarMensage()
        {

            IMessageChannel? canalEnvio2 = Channel as IMessageChannel;

            List<Embed> embed2 = new List<Embed>();
            foreach (EmbedBuilder embed in Embeds)
            {
                embed2.Add(embed.Build());
            }

            await canalEnvio2.SendMessageAsync(text: Mensage, embeds: embed2.ToArray());

        }

    }
}

