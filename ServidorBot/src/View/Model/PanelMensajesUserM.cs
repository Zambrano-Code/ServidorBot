using Discord;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.View.Model
{
    public class PanelMensajesUserM
    {
        public IDMChannel User { get; set; }
        public string Mensaje { get; set; }
        public ObservableCollection<EmbedBuilder> Embeds { get; set; } = new ObservableCollection<EmbedBuilder>();
        public ObservableCollection<IMessage> Messages { get; set; } = new ObservableCollection<IMessage>();
    }
}
