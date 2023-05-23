using Discord;
using ServidorBot.src.View.View;
using ServidorBot.src.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.View.Command
{
    public class EditEmbedCommand : CommandBase
    {
        private readonly ObservableCollection<EmbedBuilder> embeds;
        public EditEmbedCommand(ObservableCollection<EmbedBuilder> embeds)
        {
            this.embeds = embeds;
        }

        public override void Execute(object parameter)
        {
            var index = (int)parameter;
            EmbedBuilder embedTemp = embeds[index - 1];
            CrearEmbedVM viewModel = new(embedTemp);
            CrearEmbed crearEmbed = new()
            {
                DataContext = viewModel
            };

            crearEmbed.ShowDialog();

            embedTemp = viewModel.EmbedBuilder();
            embeds[index - 1] = embedTemp;
        }
    }
}
