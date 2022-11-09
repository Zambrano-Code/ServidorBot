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
    public class Mensage
    {
        public string mensage { get; private set; }
        public EmbedBuilder embed { get; private set; }
        public SocketChannel canalEnvio { get; private set; }
        public string name { get; private set; }

        public Mensage(string name, string mensage, EmbedBuilder embed, SocketChannel canalEnvio)
        {

            this.name = name;
            this.mensage = mensage;
            this.embed = embed;
            this.canalEnvio = canalEnvio;
        }
        

        public async void ejecutarMensage()
        {

            IMessageChannel? canalEnvio2 = canalEnvio as IMessageChannel;

            Embed? embed2 = null;
            if (embed != null)
            {
                embed2 = embed.Build();
            }

            await canalEnvio2.SendMessageAsync(mensage, false, embed2);

        }

    }
}

