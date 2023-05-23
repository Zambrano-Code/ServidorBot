using Discord;
using ServidorBot.src.View.Command;
using ServidorBot.src.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Resources;
using System.Collections.ObjectModel;
using ServidorBot.src.View.UserControls;

namespace ServidorBot.src.View.ViewModel
{
    public class CrearEmbedVM : ViewModelBase
    {
        public CrearEmbedM Model { get; set; } = new CrearEmbedM();
        public ICommand SubmitEmbed { get; }
        public ICommand CancelEmbed { get; }

        #region Propiedades
        private string _authorName;
        public string AuthorName
        {
            get { return _authorName; }
            set { _authorName = value; OnPropertyChanged(nameof(AuthorName)); }
        }

        private string _authorURL;
        public string AuthorURL
        {
            get { return _authorURL; }
            set { _authorURL = value; OnPropertyChanged(nameof(AuthorURL)); }
        }

        private string _authorURLIcon;
        public string AuthorURLIcon
        {
            get { return _authorURLIcon; }
            set { _authorURLIcon = value; OnPropertyChanged(nameof(AuthorURLIcon)); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        private string _urlTitle;
        public string URLTitle
        {
            get { return _urlTitle; }
            set { _urlTitle = value; OnPropertyChanged(nameof(URLTitle)); }
        }

        private System.Windows.Media.Color _color;
        public System.Windows.Media.Color Color
        {
            get { return _color; }
            set { _color = value; OnPropertyChanged(nameof(Color)); }
        }

        private string _thumbnailURL;
        public string ThumbnailURL
        {
            get { return _thumbnailURL; }
            set { _thumbnailURL = value; OnPropertyChanged(nameof(ThumbnailURL)); }
        }

        private string _footerText;
        public string FooterText
        {
            get { return _footerText; }
            set { _footerText = value; OnPropertyChanged(nameof(FooterText)); }
        }

        private string _footerTextURL;
        public string FooterTextURL
        {
            get { return _footerTextURL; }
            set { _footerTextURL = value; OnPropertyChanged(nameof(FooterTextURL)); }
        }

        private DateTime _timeStamp;
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; OnPropertyChanged(nameof(TimeStamp)); }
        }

        private string _imageURL;
        public string ImageURL
        {
            get { return _imageURL; }
            set { _imageURL = value; OnPropertyChanged(nameof(ImageURL)); }
        }

        public bool AceptedCreacion { get; private set; } = false;

        private ObservableCollection<ModeloItemField> _fields = new ObservableCollection<ModeloItemField>();
        public ObservableCollection<ModeloItemField> Fields
        {
            get { return _fields; }
            set { _fields = value; OnPropertyChanged(nameof(Fields)); }
        }

        #endregion

        public CrearEmbedVM(EmbedBuilder embed)
        {
            Model.EmbedBuilder = embed;

            AuthorName = embed.Author.Name;
            AuthorURL = embed.Author.Url;
            AuthorURLIcon = embed.Author.IconUrl;
            Title = embed.Title;
            Description = embed.Description;
            URLTitle = embed.Url;
            if (embed.Color != null) { Color = System.Windows.Media.Color.FromRgb(embed.Color.Value.R, embed.Color.Value.G, embed.Color.Value.B); }
            else { Color = Colors.White; }
            ThumbnailURL = embed.ThumbnailUrl;
            FooterText = embed.Footer.Text;
            FooterTextURL = embed.Footer.IconUrl;
            if (embed.Timestamp != null) { TimeStamp = embed.Timestamp.Value.DateTime; }
            else { TimeStamp = new DateTime(); }
            ImageURL = embed.ImageUrl;
            ConvertirAItemFields(embed.Fields, Fields);

            SubmitEmbed = new SubmitEmbedCommand(this);
            CancelEmbed = new CancelEmbedCommand();
        }

        public CrearEmbedVM()
        {
            this.Model = new CrearEmbedM()
            {
                EmbedBuilder = new EmbedBuilder()
            };

            Color = Colors.White;

            SubmitEmbed = new SubmitEmbedCommand(this);
            CancelEmbed = new CancelEmbedCommand();
        }

        public void ErrorEmbed()
        {
            var resourceManager = new ResourceManager("ServidorBot.Resources.Recursos", typeof(CrearEmbedVM).Assembly);
            var myString = resourceManager.GetString("CREATE_EMBED_MENSAJE_ERROR_EMBED");
            MessageBox.Show(myString, "Error");
        }

        public void ErrorField()
        {
            var resourceManager = new ResourceManager("ServidorBot.Resources.Recursos", typeof(CrearEmbedVM).Assembly);
            var myString = resourceManager.GetString("CREATE_EMBED_MENSAJE_ERROR_FIELD");
            MessageBox.Show(myString, "Error");
        }

        public bool VerificarEmbed()
        {

            if (string.IsNullOrEmpty(AuthorName) &&
                string.IsNullOrEmpty(Title) &&
                string.IsNullOrEmpty(Description) &&
                string.IsNullOrEmpty(FooterText) &&
                Fields.Count == 0)
            {
                ErrorEmbed();
                return false;
            }

            try
            {
                GetList();
            }
            catch (Exception ex)
            {
                ErrorField();
                return false;
            }
            AceptedCreacion = true;
            return true;
        }


        public EmbedBuilder EmbedBuilder()
        {
            return new EmbedBuilder
            {
                Author = EmbedAuthor(),
                Title = Title,
                Url = URLTitle,
                Description = Description,
                Color = ToDiscordColor(Color),
                ImageUrl = ImageURL,
                ThumbnailUrl = ThumbnailURL,
                Timestamp = ValidateTimeStamp(),
                Footer = EmbedFooter(),
                Fields = GetList(),
            };
        }

        public static Discord.Color ToDiscordColor(System.Windows.Media.Color color)
        {
            return new Discord.Color(color.R, color.G, color.B);
        }
        private List<EmbedFieldBuilder> GetList()
        {

            List<EmbedFieldBuilder> temp = new List<EmbedFieldBuilder>();
            foreach (var item in Fields)
            {
                temp.Add(new EmbedFieldBuilder
                {
                    IsInline = item.Checked,
                    Name = item.Name,
                    Value = item.Value,
                });
            }
            return temp;
        }
        private EmbedAuthorBuilder EmbedAuthor()
        {
            return new EmbedAuthorBuilder
            {
                Name = AuthorName,
                Url = AuthorURL,
                IconUrl = AuthorURLIcon
            };
        }
        private EmbedFooterBuilder EmbedFooter()
        {
            return new EmbedFooterBuilder
            {
                Text = FooterText,
                IconUrl = FooterTextURL,
            };
        }

        private DateTime? ValidateTimeStamp()
        {
            if (TimeStamp.Year < 2000)
            {
                return null;
            }
            return TimeStamp;
        }

        private ObservableCollection<ModeloItemField> ConvertirAItemFields(List<EmbedFieldBuilder> embedFields, ObservableCollection<ModeloItemField> itemFields)
        {
            itemFields.Clear();
            int index = 1;

            foreach (var field in embedFields)
            {
                itemFields.Add(new ModeloItemField
                {
                    Name = field.Name,
                    Value = (string)field.Value,
                    Checked = false,
                    Index = index
                });

                index++;
            }

            return itemFields;
        }

    }
}
