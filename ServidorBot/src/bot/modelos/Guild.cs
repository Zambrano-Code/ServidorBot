using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.WebSocket;

namespace bot.modelos
{
    public class Guild
    {
        public string lang { get; set; }
        public ulong id { get; set; }

        public Guild( ulong id, string lang)
        {
            this.lang = lang;
            this.id = id;
        }
    }
}
