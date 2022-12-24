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
    /// Lógica de interacción para TextBoxLimText.xaml
    /// </summary>
    public partial class TextBoxLimText : UserControl
    {
        public ModelTextBoxLimText _modelTextBoxLimText { get; set; }
        public TextBoxLimText()
        {
          
            InitializeComponent();

            DataContext = _modelTextBoxLimText;
        }
    }
}
