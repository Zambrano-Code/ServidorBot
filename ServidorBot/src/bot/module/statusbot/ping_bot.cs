using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace bot.module.statusbot
{
    [Group("bot")]
    public class ping_bot : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task pingBot()
        {
            Ping myPing = new Ping();
            PingReply reply = myPing.Send("8.8.8.8", 1000);

            await ReplyAsync($"Ping: {reply.RoundtripTime.ToString()}ms");
        }

    }
}
