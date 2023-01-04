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
    /// Lógica de interacción para AddFields.xaml
    /// </summary>
    public partial class AddFields : UserControl
    {


        public AddFields()
        {
            InitializeComponent();

        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            ModeloAddFields dt = DataContext as ModeloAddFields;

            dt.addElemten(new ModeloItemField
            {
                ModelTextBoxLimName = new ModelTextBoxLimText
                {
                    Name = Datos.Labels.ViewCreateEmbed.FieldName,
                    Length = 256,


                },
                ModelTextBoxLimValue = new ModelTextBoxLimText
                {
                    Name = Datos.Labels.ViewCreateEmbed.FieldValue,
                    Length = 1024,
                    Return = true,

                },
                ModelTextBoxLimInline = Datos.Labels.ViewCreateEmbed.FieldInline,
                ModelTextBoxLimInlineChecked = false,
                Index = dt.EmbedFieldBuilders.Count + 1,

            });
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            ModeloAddFields dt = DataContext as ModeloAddFields;

            if (dt.EmbedFieldBuilders.Count == 0) return;
            dt.EmbedFieldBuilders.RemoveAt(dt.EmbedFieldBuilders.Count- 1);
        }
    }
}
