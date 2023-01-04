using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ServidorBot.src.View.Clases
{
    public class IMensajeUser
    {

        private string _nombre;
        private string _fecha;
        private string _mensaje;
        private string _embeds;
        private Brush _icon;
        private List<Border> _img = new();

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public Brush Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public List<Border> Img
        {
            get { return _img; }
            set { _img = value; }
        }

        public string Embeds
        {
            get { return _embeds; }
            set { _embeds = value; }
        }

    }
}
