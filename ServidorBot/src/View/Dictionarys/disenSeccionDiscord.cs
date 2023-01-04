using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ServidorBot.Dictionarys
{
    partial class disenSeccionDiscord
    {
        private CheckBox seccionSelection;

        private void accion_click(object sender, RoutedEventArgs e)
        {
            var sc = (CheckBox)sender;
            if (seccionSelection == null) { seccionSelection = sc; return; }
            if (sc == seccionSelection ) { seccionSelection.IsChecked = true; return; }

            seccionSelection.IsChecked = false;
            sc.IsChecked = true;

            seccionSelection = sc;
        }

    }
}
