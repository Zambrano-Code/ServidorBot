using Discord;
using ServidorBot.src.View.Model;
using ServidorBot.src.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.View.Command
{
    public class SelectUserCommand : CommandBase
    {
        private SeccionMensajeVM SeccionMensajeVM;
        public SelectUserCommand(SeccionMensajeVM viewModel)
        {
            this.SeccionMensajeVM = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter == null) return;
            if (parameter is IDMChannel User)
            {

                SeccionMensajeVM.UserSelectVM.User = User;

            }
        }
    }
}
