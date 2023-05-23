using Discord.WebSocket;
using ServidorBot.src.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.View.Command
{
    public class UpdateVMCommand : CommandBase
    {
        private MainWindowVM viewModel;
        public UpdateVMCommand(MainWindowVM vm)
        {
            this.viewModel = vm;
        }

        public override void Execute(object parameter)
        {
            if (parameter is string str)
            {
                if (str == "Mensajes")
                {
                    viewModel.SelectedVM = new SeccionMensajeVM();
                }
            }
            if (parameter is SocketGuild guild)
            {
                viewModel.SelectedVM = new SeccionDiscordEventosVM(guild);

            }

        }
    }
}
