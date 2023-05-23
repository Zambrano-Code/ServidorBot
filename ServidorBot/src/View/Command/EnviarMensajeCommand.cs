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
    public class EnviarMensajeCommand : CommandBase
    {
        private readonly PanelMensajesUserVM PanelMensajesUserVM;
        public EnviarMensajeCommand(PanelMensajesUserVM Model)
        {
            this.PanelMensajesUserVM = Model;
        }

        public override void Execute(object parameter)
        {
            var user = PanelMensajesUserVM.User;

            string msg = PanelMensajesUserVM.Model.Mensaje;
            List<Embed> list = new List<Embed>();

            foreach (var i in PanelMensajesUserVM.Model.Embeds)
            {
                list.Add(i.Build());
            }

            try
            {
                var result = user.SendMessageAsync(text: msg, embeds: list.ToArray()).Result;

                if (result == null) return;

                PanelMensajesUserVM.ClearMessage();
                PanelMensajesUserVM.Model.Messages.Add(result);

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
