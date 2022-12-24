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
    /// Lógica de interacción para BarraPrincipal.xaml
    /// </summary>
    public partial class BarraPrincipal : UserControl
    {

        public ModelBarraPrincipal _modelBarraPrincipal { get; set; }

        public BarraPrincipal()
        {
            InitializeComponent();

            DataContext = _modelBarraPrincipal;
        }

        private void window_Movible(object sender, MouseButtonEventArgs e)
        {
            var dt = DataContext as ModelBarraPrincipal;
            if (dt.ViewWindow == null) { throw new Exception("No hay ventana para arrastrar"); }
            if (e.LeftButton == MouseButtonState.Pressed)
                dt.ViewWindow.DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            var dt = DataContext as ModelBarraPrincipal;

            dt.ViewWindow.Close();
        }

        private void Max_Click(object sender, RoutedEventArgs e)
        {
            var dt = DataContext as ModelBarraPrincipal;

            dt.ViewWindow.WindowState= WindowState.Maximized;
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            var dt = DataContext as ModelBarraPrincipal;

            dt.ViewWindow.WindowState = WindowState.Minimized;
        }
    }
}
