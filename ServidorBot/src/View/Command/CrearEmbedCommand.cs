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
    public class CrearEmbedCommand : CommandBase
    {
        private ObservableCollection<EmbedBuilder> embeds;

        public CrearEmbedCommand(ObservableCollection<EmbedBuilder> embeds)
        {
            this.embeds = embeds;
        }
        public override void Execute(object parameter)
        {
            CrearEmbedVM crearEmbedVM = new();
            CrearEmbed crearEmbed = new() { DataContext = crearEmbedVM};
            crearEmbed.ShowDialog();

           if(crearEmbedVM.AceptedCreacion)
            {
                var embed = crearEmbedVM.EmbedBuilder();
                if (embed != null) { embeds.Add(embed); }
            }
        }
    }
}
