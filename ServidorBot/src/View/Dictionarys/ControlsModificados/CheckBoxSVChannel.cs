using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Windows.Controls;
using Discord;
using Discord.WebSocket;

namespace ServidorBot.src.View.ControlsModificados
{
    public class CheckBoxSVChannel : CheckBox
    {
        public SocketGuild _guild { get; private set; }
        
        public CheckBoxSVChannel(SocketGuild guild)
        {
            _guild = guild;
        }
    }
}
