using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ServidorBot.View.Dictionarys
{
    public partial class dicenElement
    {


        public dicenElement() { }

        public CheckBox checkBox { get; private set; }
        private void Botn_Click(object sender, RoutedEventArgs e)
        {
            var ck = (CheckBox)sender;

            if (checkBox == null) { checkBox = ck; }
            else if (checkBox == ck) { ck.IsChecked = true; }
            else if (checkBox != ck) { checkBox.IsChecked = false; checkBox = ck; }

            return;

        }

    }
}
