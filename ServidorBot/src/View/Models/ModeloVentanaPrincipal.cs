using bot;
using ServidorBot.src.Datos;
using ServidorBot.src.View.ControlsModificados;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServidorBot.src.View.Models
{
    public class ModeloVentanaPrincipal : ViewModelBase
    {
        #region Propiedades
        private Bot _bot = new Bot();

        private ObservableCollection<CheckBoxSVChannel> _listDm;
        private ModelBarraPrincipal _barraPrincipal;

        public ModelBarraPrincipal BarraPrincipal
        {
            get { return _barraPrincipal; }
            set { if(_barraPrincipal == null) _barraPrincipal = value; }
        }
        public ObservableCollection<CheckBoxSVChannel> ListaServidores
        {
            get { return _listDm; }
        }
        
        public Bot Bot
        {
            get { return _bot; }
        }

        #endregion

        public ModeloVentanaPrincipal()
        {
            _listDm = new ObservableCollection<CheckBoxSVChannel>();
        }
    }
}
