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
    /// Lógica de interacción para DataTimePicker.xaml
    /// </summary>
    public partial class DataTimePicker : UserControl
    {
        public DataTimePicker()
        {
            InitializeComponent();

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ModelDateTimePicker dtp = DataContext as ModelDateTimePicker;
            dtp.Date = new DateTime();
            dtp.Time = new TimeSpan();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ModelDateTimePicker dtp = DataContext as ModelDateTimePicker;

            e.Handled = true;
            //dp.SelectedDate = 
            foreach (var a in e.AddedItems)
            {

                Console.WriteLine(a);
                dtp.Date = DateTime.Parse(a.ToString());
            }
        }

        private void PickTime_TimeSelect(PickTime pt, TimeSpan Msg)
        {
            ModelDateTimePicker dtp = DataContext as ModelDateTimePicker;

            dtp.Time = pt.Time;
        }
    }
}
