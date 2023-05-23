using bot.acciones;
using Discord;
using Discord.WebSocket;
using ServidorBot.src.View.Command;
using ServidorBot.src.View.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServidorBot.src.View.ViewModel
{
    public class PanelMensajesUserVM : ViewModelBase
    {
        public PanelMensajesUserM Model { get; set; } = new PanelMensajesUserM();

        private int MessageLimit = 100;


        #region Propiedades publicas
        public IDMChannel User
        {
            get { return Model.User; }
            set { Model.User = value; LoadMessagesAsync(); OnPropertyChanged(nameof(User)); }
        }

        public string Mensaje
        {
            get { return Model.Mensaje; }
            set { Model.Mensaje = value; OnPropertyChanged(nameof(Mensaje)); }
        }
        #endregion



        public PanelMensajesUserVM()
        {

            //Declaracion de Commandos
            EnviarMensajeCommand = new EnviarMensajeCommand(this);
            CrearEmbedCommand = new CrearEmbedCommand(Model.Embeds);
            EditEmbedCommand = new EditEmbedCommand(Model.Embeds);
            DeleteEmbedCommand = new DeleteEmbedCommand(Model.Embeds);


        }

        public async void LoadMessagesAsync()
        {
            Model.Messages.Clear();
            var messagesTe = await Model.User.GetMessagesAsync(MessageLimit).FlattenAsync();

            foreach (var message in messagesTe.Reverse())
            {
                Model.Messages.Add(message);
            }

        }

        public void ClearMessage()
        {
            Model.Embeds.Clear();
            Mensaje = "";
        }

        public void addMesages(int max = 100)
        {
            MessageLimit += max;
            LoadMessagesAsync();
        }

        public void addMesage(IMessage msg)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Model.Messages.Add(msg);
            });
        }

        #region Commandos
        public ICommand EnviarMensajeCommand { get; set; }
        public ICommand CrearEmbedCommand { get; set; }
        public ICommand EditEmbedCommand { get; set; }
        public ICommand DeleteEmbedCommand { get; set; }
        #endregion
    }
}
