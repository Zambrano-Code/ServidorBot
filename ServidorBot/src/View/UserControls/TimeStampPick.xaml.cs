using ServidorBot.src.View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServidorBot.src.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para TimeStampPick.xaml
    /// </summary>
    public partial class TimeStampPick : UserControl
    {
        public ModelTimeStampPick _modelTimeStampPick { get; set; }


        public TimeStampPick()
        {
            InitializeComponent();

            DataContext = _modelTimeStampPick;
        }

        private void DeteleTextDataPick_Click(object sender, RoutedEventArgs e)
        {
            //DatePick.Text = "";
        }
    }
}
