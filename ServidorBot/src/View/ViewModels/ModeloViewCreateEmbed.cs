using ServidorBot.src.View.Models;
using ServidorBot.src.View.UserControls;
using ServidorBot.src.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Discord.WebSocket;
using Discord;

namespace ServidorBot.src.View.ViewModels
{
    public class ModeloViewCreateEmbed //: ViewModelBase
    {
        #region Properties
        public EmbedBuilder socketEmbed { get; set; }
        public ModelTextBoxLimText AuthorName_modelTextmodelText { get; set; }
        public ModelTextBoxLimText AuthorURL_modelTextmodelText { get; set; }
        public ModelTextBoxLimText AuthorURLIcon_modelTextmodelText { get; set; }
        public ModelTextBoxLimText Title_modelTextmodelText { get; set; }
        public ModelTextBoxLimText Description_modelTextmodelText { get; set; }
        public ModelTextBoxLimText URLTitle_modelTextmodelText { get; set; }
        public ModelSelectorColorTextBlock Color_modelSelectorColorTextBlock { get; set; }
        public ModelTextBoxLimText ImageURL_modelTextmodelText { get; set; }
        public ModelTextBoxLimText ThumbnailURL_modelTextmodelText { get; set; }
        public ModelTextBoxLimText FooterText_modelTextmodelText { get; set; }
        public ModelTextBoxLimText FooterTextURL_modelTextmodelText { get; set; }
        public ModelTimeStampPick TimeStamp_ModelTimeStampPick { get; set; }
        #endregion

        public ModeloViewCreateEmbed()
        {
            socketEmbed = new EmbedBuilder();
            //socketEmbed.T

            AuthorName_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.viewCreateEmbed.AuthorName,
                Length = 256,
            };

            AuthorURL_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.viewCreateEmbed.AuthorUrl,
                VisibleCount = Visibility.Collapsed
            };

            AuthorURLIcon_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.viewCreateEmbed.AuthorUrlIcon,
                VisibleCount = Visibility.Collapsed
            };

            Title_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.viewCreateEmbed.Title,
                Length = 256,
            };

            Description_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.viewCreateEmbed.Description,
                Length = 2048,
                Return = true,
                MaxHeight = 250,
            };

            URLTitle_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.viewCreateEmbed.URLTitle,
                VisibleCount = Visibility.Collapsed,
            };

            Color_modelSelectorColorTextBlock = new ModelSelectorColorTextBlock()
            {
                Color = "#FFFFFFFF",
                Text = Datos.Labels.viewCreateEmbed.Color,
            };

            ImageURL_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.viewCreateEmbed.ImageURL,
                VisibleCount = Visibility.Collapsed,
            };

            ThumbnailURL_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.viewCreateEmbed.ThumbnailURL,
                VisibleCount = Visibility.Collapsed,
            };

            FooterText_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.viewCreateEmbed.FooterText,
                Length = 256,
            };

            FooterTextURL_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.viewCreateEmbed.FooterTextURL,
                VisibleCount= Visibility.Collapsed,
            };

            TimeStamp_ModelTimeStampPick = new ModelTimeStampPick()
            {
                Text = Datos.Labels.viewCreateEmbed.TimeStamp,
            };

        }
    }
}
