using ServidorBot.src.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.View.ViewModel
{
    public class CrearEventoVM : ViewModelBase
    {
        private CrearEventoM model;
        public CrearEventoM Model{ get { return model; } set { model = value; OnPropertyChanged(nameof(Model)); } }

        public CrearEventoVM()
        {
            model = new CrearEventoM()
            {
                NameEvento = "Evento 1",
                DateInit = new DateTime(year: 2023, month: 1, day: 1),
                TimeRepeat = new TimeSpan(hours:0, minutes:30, seconds: 0),
                UTC = false
            };
        }
    }
}

