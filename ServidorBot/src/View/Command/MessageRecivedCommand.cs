using Discord.WebSocket;
using ServidorBot.src.View.UserControls;
using ServidorBot.src.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.View.Command
{
    public class MessageRecivedCommand : CommandBase
    {
        private readonly SeccionMensajeVM _viewModel;
        public MessageRecivedCommand(SeccionMensajeVM viewModel)
        {
            this._viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            if (parameter is SocketMessage arg)
            {
                if (arg.Author.Username == _viewModel.UserSelect.Recipient.Username)
                {
                    _viewModel.UserSelectVM.addMesage(arg);
                }
            }
        }
    }
}
