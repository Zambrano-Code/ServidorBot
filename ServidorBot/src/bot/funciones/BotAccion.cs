using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace bot.funciones
{
    public class BotAccion
    {
        public static async void mensage(String text, Embed embed, SocketChannel canal)
        {
            IMessageChannel? canalEnvio = canal as IMessageChannel;

            await canalEnvio.SendMessageAsync(text , false , embed);
        }

        //public static 
    }
}
