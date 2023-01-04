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
using System.Collections.ObjectModel;
using System.Windows.Controls;
using ServidorBot.src.View.Clases;
using System.Windows.Media;
using System.ComponentModel;
using Google.Protobuf.WellKnownTypes;

namespace ServidorBot.src.View.ViewModels
{
    public class ModeloViewCreateEmbed //: ViewModelBase
    {
        #region Properties
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
        public ModeloAddFields AddField_ModeloAddFields { get; set; }

        #endregion

        public ModeloViewCreateEmbed(EmbedBuilder embedBuiler)
        {

            AuthorName_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.ViewCreateEmbed.AuthorName,
                Length = 256,
                Text = embedBuiler.Author == null ? "" : embedBuiler.Author.Name,
            };

            AuthorURL_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.ViewCreateEmbed.AuthorUrl,
                VisibleCount = Visibility.Collapsed,
                Text = embedBuiler.Author == null ? "" : embedBuiler.Author.Url,

            };

            AuthorURLIcon_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.ViewCreateEmbed.AuthorUrlIcon,
                VisibleCount = Visibility.Collapsed,
                Text = embedBuiler.Author == null ? "" : embedBuiler.Author.IconUrl,
            };

            Title_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.ViewCreateEmbed.Title,
                Length = 256,
                Text = embedBuiler.Title == null ? "" : embedBuiler.Title,
            };

            Description_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.ViewCreateEmbed.Description,
                Length = 2048,
                Return = true,
                MaxHeight = 250,
                Text = embedBuiler.Description == null ? "" : embedBuiler.Description
            };

            URLTitle_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.ViewCreateEmbed.URLTitle,
                VisibleCount = Visibility.Collapsed,
                Text = embedBuiler.Url == null ? "" : embedBuiler.Url
            };

            Color_modelSelectorColorTextBlock = new ModelSelectorColorTextBlock()
            {
                Color = embedBuiler.Color.ToString() == "" ? "#ffffffff" : embedBuiler.Color.ToString(),
                Text = Datos.Labels.ViewCreateEmbed.Color,
            };

            ImageURL_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.ViewCreateEmbed.ImageURL,
                VisibleCount = Visibility.Collapsed,
                Text = embedBuiler.ImageUrl == null ? "" : embedBuiler.ImageUrl,
            };

            ThumbnailURL_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.ViewCreateEmbed.ThumbnailURL,
                VisibleCount = Visibility.Collapsed,
                Text = embedBuiler.ThumbnailUrl == null ? "" : embedBuiler.ThumbnailUrl
            };

            FooterText_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.ViewCreateEmbed.FooterText,
                Length = 256,
                Text = embedBuiler.Footer == null ? "" : embedBuiler.Footer.Text
            };

            FooterTextURL_modelTextmodelText = new ModelTextBoxLimText()
            {
                Name = Datos.Labels.ViewCreateEmbed.FooterTextURL,
                VisibleCount = Visibility.Collapsed,
                Text = embedBuiler.Footer == null ? "" : embedBuiler.Footer.IconUrl,
            };

            var a = embedBuiler.Timestamp == null ? new DateTime() : DateTime.Parse(embedBuiler.Timestamp.ToString());
            TimeStamp_ModelTimeStampPick = new ModelTimeStampPick()
            {
                Text = Datos.Labels.ViewCreateEmbed.TimeStamp,
                DateTime = new ModelDateTimePicker()
                {
                    DateTime = a,
                }
            };

            AddField_ModeloAddFields = new ModeloAddFields()
            {
                ListMax = 10,
                EmbedFieldBuilders = getFielObserver(embedBuiler.Fields)

            };


        }

        public EmbedBuilder getEmbed()
        {
            EmbedBuilder socketEmbed = new EmbedBuilder();

            socketEmbed.Author = new EmbedAuthorBuilder()
            {
                Name = AuthorName_modelTextmodelText.Text,
                Url = AuthorURL_modelTextmodelText.Text,
                IconUrl = AuthorURLIcon_modelTextmodelText.Text,
            };

            socketEmbed.Title = Title_modelTextmodelText.Text;
            socketEmbed.Description = Description_modelTextmodelText.Text;
            socketEmbed.Url = URLTitle_modelTextmodelText.Text;

            System.Windows.Media.Color temp = (System.Windows.Media.Color)ColorConverter.ConvertFromString(Color_modelSelectorColorTextBlock.Color); ;
            socketEmbed.Color = new Discord.Color(temp.R, temp.G, temp.B);
            socketEmbed.ImageUrl = ImageURL_modelTextmodelText.Text;
            socketEmbed.Footer = new EmbedFooterBuilder
            {
                IconUrl = FooterTextURL_modelTextmodelText.Text,
                Text = FooterText_modelTextmodelText.Text,
            };

            if (TimeStamp_ModelTimeStampPick.DateTime.DateTime != new DateTime())
            {
                socketEmbed.Timestamp = TimeStamp_ModelTimeStampPick.DateTime.DateTime;
            }
            socketEmbed.Fields = AddField_ModeloAddFields.getList();
            return socketEmbed;
        }

        private ObservableCollection<ModeloItemField> getFielObserver(List<EmbedFieldBuilder> efb)
        {
            ObservableCollection<ModeloItemField> mdl = new ObservableCollection<ModeloItemField>();
            int a = 1;
            foreach (var item in efb)
            {
                var temp = new ModeloItemField()
                {
                    ModelTextBoxLimName = new ModelTextBoxLimText
                    {
                        Name = Datos.Labels.ViewCreateEmbed.FieldName,
                        Length = 256,
                        Text = item.Name

                    },
                    ModelTextBoxLimValue = new ModelTextBoxLimText
                    {
                        Name = Datos.Labels.ViewCreateEmbed.FieldValue,
                        Length = 1024,
                        Return = true,
                        Text = item.Value.ToString()

                    },
                    ModelTextBoxLimInline = Datos.Labels.ViewCreateEmbed.FieldInline,
                    ModelTextBoxLimInlineChecked = item.IsInline,
                    Index = a,

                };
                mdl.Add(temp);
                a++;
            }
            return mdl;
        }
    }
}
