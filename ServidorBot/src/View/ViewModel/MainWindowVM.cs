using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using bot;
using Discord.WebSocket;
using ServidorBot.src.View.Command;
using ServidorBot.src.View.Model;
using ServidorBot.src.View.UserControls;
using ServidorBot.src.View.View;

namespace ServidorBot.src.View.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        public MainWindowM Model { get; set; }

        private ViewModelBase selectedVM;
        public ViewModelBase SelectedVM
        {
            get { return selectedVM; }
            set { selectedVM = value; OnPropertyChanged(nameof(SelectedVM)); }
        }

        public MainWindowVM()
        {
            Model = new MainWindowM()
            {
                ListServer = GetGuilds(),
            };

            UpdateVMCommand = new UpdateVMCommand(this);

            var temp = new SeccionMensajeVM();
            
            SelectedVM = temp;
        }

        public ObservableCollection<SocketGuild> GetGuilds()
        {
            var guilds = App.Bot._cliente.Guilds;

            ObservableCollection<SocketGuild> temp = new ObservableCollection<SocketGuild>(guilds.ToList());
            return temp;
        }

        public ICommand UpdateVMCommand { get; set; }

    }
}
