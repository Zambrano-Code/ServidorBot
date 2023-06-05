using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Windows.Controls;
using Discord;

namespace ServidorBot.src.View.ControlsModificados
{
    public class CheckBoxDMChannel : CheckBox
    {
        public IDMChannel _iDMChannel { get; private set; }
        
        public CheckBoxDMChannel(IDMChannel dMChannel)
        {
            _iDMChannel = dMChannel;
        }
    }
}
