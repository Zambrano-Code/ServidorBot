using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.Datos
{
    public class Labels
    {
        #region Ventanas
        public const string NickWindowsMain = "Secretaria Bot";
        public const string NickWindowsCreateEmbed = "Create Embed";
        public const string NickWindowsCreateEvento = "Create Evento";
        #endregion

        #region Pages
        public const string UrlPage = "pack://application:,,,/src/view/pages/SeccionMensaje.xaml";
        public const string UrlPage2 = "pack://application:,,,/src/view/pages/SeccionDiscordEventos.xaml";
        #endregion

        #region Create Embed
        public class ViewCreateEmbed
        {
            public const string AuthorName = "Nombre: ";
            public const string AuthorUrl = "URL: ";
            public const string AuthorUrlIcon = "URL Icono: ";

            public const string Title = "Titulo: ";
            public const string Description = "Descripcion: ";
            public const string URLTitle = "URL: ";

            public const string Color = "Color: ";

            public const string ImageURL = "Imagen URL: ";
            public const string ThumbnailURL = "ThumbnailURL: ";
            public const string FooterText = "Texto Footer: ";
            public const string FooterTextURL = "Footer Icon URL: ";

            public const string TimeStamp = "Time Stamp: ";

            public const string FieldName = "Nombre: ";
            public const string FieldValue = "Valor: ";
            public const string FieldInline = "Inline: ";

            public const string MensajeEmbedError = "Debes de completar alemenos: \n-Author\n-Titulo\n-Descripcion\n-Footer\n-o agregar un Field.";
            public const string MensajeFieldError = "Deves de llenar los field tanto el nombre como el valor.";
        }
        #endregion

        #region Create Evento
        public class CreateEvento
        {
            public const string Nombre = "Nombre: ";
            public const string TimeInit = "Hora de inicio: ";
            public const string TImeRepeat = "Tiempo a repetir: ";
            public const string ZoneHour = "Zona Horaria: ";
        }
        #endregion
    }

}
