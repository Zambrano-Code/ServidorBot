using Discord;
using Org.BouncyCastle.Bcpg.OpenPgp;
using ServidorBot.src.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.View.Model
{
    public class SeccionMensajeM
    {

        public ObservableCollection<IDMChannel> Users { get; set; }
        public IDMChannel UserSelect { get; set; }

}
}
