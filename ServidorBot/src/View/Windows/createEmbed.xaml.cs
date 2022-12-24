using ServidorBot.src.View.Models;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            set
            {
                //Se le arrega el codicional para que no remplace el Elemento ventana o dara error al cerrar o interacturar
                if (_barraPrincipal == value) { return; }
                _barraPrincipal = value;
                //OnPropertyChanged(nameof(BarraPrincipal));
            }
        }
        #endregion

        public createEmbed()
        {
            #region Configuracion Ventana
            BarraPrincipal = new ModelBarraPrincipal()
            {
                Title = Datos.Labels.NickWindowsCreateEmbed,
                Maximize = Visibility.Collapsed,
                ViewWindow = this
            };
            #endregion

            InitializeComponent();
            DataContext = this;
        }

        public void getEmbed()
        {
            this.ShowDialog();
            Visibility = Visibility.Visible;
        }

    }
}
