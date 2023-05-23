using Discord;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.View.Command
{
    public class DeleteEmbedCommand : CommandBase
    {
        private readonly ObservableCollection<EmbedBuilder> embeds;
        public DeleteEmbedCommand(ObservableCollection<EmbedBuilder> embeds)
        {
            this.embeds = embeds;
        }

        public override void Execute(object parameter)
        {
            int index = (int)parameter - 1;
            embeds.RemoveAt(index);
        }
    }
}
