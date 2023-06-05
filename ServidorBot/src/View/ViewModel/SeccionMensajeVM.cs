using Discord;
using ServidorBot.src.View.Command;
using ServidorBot.src.View.Model;
using ServidorBot.src.View.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServidorBot.src.View.ViewModel
{
    public class SeccionMensajeVM : ViewModelBase
    {
        private SeccionMensajeM Model { get; set; } = new SeccionMensajeM();


        #region propiedades publicas
        public PanelMensajesUserVM userSelectVM;
        public PanelMensajesUserVM UserSelectVM
        {
            get { return userSelectVM; }
            set { userSelectVM = value; OnPropertyChanged(nameof(UserSelectVM)); }
        }
        public ObservableCollection<IDMChannel> Users
        {
            get { return Model.Users; }
            set { Model.Users = value; OnPropertyChanged(nameof(Users)); }
        }
        public IDMChannel UserSelect
        {
            get { return Model.UserSelect; }
            set { Model.UserSelect = value; OnPropertyChanged(nameof(UserSelect)); }

        }
        #endregion


        #region Commandos
        public ICommand SelectUser { get; set; }
        public ICommand MessageRecived { get; set; }
        #endregion


        public SeccionMensajeVM()
        {
            //Declaracion de los comandos
            SelectUser = new SelectUserCommand(this);
            MessageRecived = new MessageRecivedCommand(this);


            if (Model != null) { RefresUsers(); }
            if (Users.Count > 0) { SelectFrishUser(); }


        }


        #region Metodos publicos
        public void RefresUsers()
        {
            Users = new ObservableCollection<IDMChannel>(App.Bot.GetUsersDMChannels());
            App.Bot._cliente.MessageReceived += _cliente_MessageReceived;
        }

        private Task _cliente_MessageReceived(Discord.WebSocket.SocketMessage arg)
        {
            MessageRecived.Execute(arg);
            return Task.CompletedTask;
        }

        public void SelectFrishUser()
        {
            UserSelectVM = new PanelMensajesUserVM()
            {
                User = Users[0],
            };
            UserSelect = Users[0];

        }

        #endregion
    }
}
