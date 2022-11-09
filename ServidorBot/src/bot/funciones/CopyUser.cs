using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.WebSocket;
using Discord;

namespace bot.funciones
{
    public class CopyUser
    {

        public async static Task<List<IGuildUser>> getListUserChannelVoice(SocketChannel chanel)
        {
            List<IGuildUser> userOn = new List<IGuildUser>();

            IVoiceChannel ichannel  = chanel as IVoiceChannel;

            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> collectIChannel = ichannel.GetUsersAsync();

            await foreach (var collUser in collectIChannel)
            {
                int cont = 0;
                foreach (var user in collUser)
                {
                    if(user.VoiceChannel != null)
                    {
                        if (user.VoiceChannel.Id == chanel.Id)
                        {
                            cont++;
                            userOn.Add(user);
                        }
                    }
                }
            }

            return userOn;

        }

    }
}
