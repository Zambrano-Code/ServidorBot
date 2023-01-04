using Discord;
using ServidorBot.src.View.Models;
using ServidorBot.src.View.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static ServidorBot.src.View.Models.ModelBarraPrincipal;
using static System.Net.Mime.MediaTypeNames;

namespace ServidorBot.src.View.Windows
{
    /// <summary>
    /// Lógica de interacción para createEmbed.xaml
    /// </summary>
    public partial class createEmbed : Window
    {

        #region Propiedades
        private ModelBarraPrincipal _barraPrincipal;

        public ModelBarraPrincipal BarraPrincipal
        {
            get { return _barraPrincipal; }
        }

        private ModeloViewCreateEmbed _modeloViewCreateEmbed;

        public ModeloViewCreateEmbed ViewCreateEmbed
        {
            get { return _modeloViewCreateEmbed; }
            set { _modeloViewCreateEmbed = value; }
        }

        public delegate void EmbedCreado(EmbedBuilder Msg);
        public event EmbedCreado embedCreate;
        #endregion

        public createEmbed(ModeloViewCreateEmbed model)
        {
            #region Configuracion Ventana
            _barraPrincipal = new ModelBarraPrincipal()
            {
                Title = Datos.Labels.NickWindowsCreateEmbed,
                Maximize = Visibility.Collapsed,
                ViewWindow = this
            };

            ViewCreateEmbed = model;
            #endregion

            InitializeComponent();
            DataContext = this;
        }

        private void Button_ClickCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_ClickAcepted(object sender, RoutedEventArgs e)
        {
            List<EmbedFieldBuilder> listField;
            try
            {
                listField = ViewCreateEmbed.AddField_ModeloAddFields.getList();
            }
            catch (Exception ex)
            {
                listField = new List<EmbedFieldBuilder>();
                errorField();
            }

            if (
                string.IsNullOrEmpty(ViewCreateEmbed.AuthorName_modelTextmodelText.Text) &&
                string.IsNullOrEmpty(ViewCreateEmbed.Title_modelTextmodelText.Text) &&
                string.IsNullOrEmpty(ViewCreateEmbed.Description_modelTextmodelText.Text) &&
                string.IsNullOrEmpty(ViewCreateEmbed.FooterText_modelTextmodelText.Text) &&
                listField.Count == 0
                )
            {
                errorEmbed();
                return;
            }



            this.Close();

            if (EmbedYaCreado != null)
                EmbedYaCreado(ViewCreateEmbed.getEmbed());

        }

        private void errorEmbed()
        {
            MessageBox.Show(Datos.Labels.ViewCreateEmbed.MensajeEmbedError, "Error");
        }

        private void errorField()
        {
            MessageBox.Show(Datos.Labels.ViewCreateEmbed.MensajeFieldError, "Error");
        }

        protected virtual void EmbedYaCreado(EmbedBuilder emb)
        {
            EmbedCreado tmp = embedCreate;
            if (tmp != null)
                tmp(emb);
        }
    }
}
