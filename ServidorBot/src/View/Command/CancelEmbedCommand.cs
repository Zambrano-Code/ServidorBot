using Discord;
using ServidorBot.src.View.Model;
using ServidorBot.src.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServidorBot.src.View.Command
{
    public class CancelEmbedCommand : CommandBase
    {
        public CancelEmbedCommand()
        {

        }

        public override void Execute(object parameter)
        {
            
            var currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();


        }

    }
}
