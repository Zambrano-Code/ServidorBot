using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace ServidorBot.src.View.UserControls
{
    public partial class AddFields : UserControl
    {

        public static readonly DependencyProperty TextAddProperty = DependencyProperty.Register(nameof(TextAdd),
                                                                                            typeof(string),
                                                                                            typeof(AddFields),
                                                                                            new PropertyMetadata("Add Field"));

        public static readonly DependencyProperty TextRemoveProperty = DependencyProperty.Register(nameof(TextRemove),
                                                                                                    typeof(string),
                                                                                                    typeof(AddFields),
                                                                                                    new PropertyMetadata("Remove Field"));

        public static readonly DependencyProperty TextNameProperty = DependencyProperty.Register(nameof(TextName),
                                                                                                    typeof(string),
                                                                                                    typeof(AddFields),
                                                                                                    new PropertyMetadata("Name"));

        public static readonly DependencyProperty TextValueProperty = DependencyProperty.Register(nameof(TextValue),
                                                                                                    typeof(string),
                                                                                                    typeof(AddFields),
                                                                                                    new PropertyMetadata("Value"));

        public static readonly DependencyProperty TextCheckedProperty = DependencyProperty.Register(nameof(TextChecked),
                                                                                                    typeof(string),
                                                                                                    typeof(AddFields),
                                                                                                    new PropertyMetadata("InLine"));

        public static readonly DependencyProperty MaxFieldProperty = DependencyProperty.Register(nameof(MaxField),
                                                                                                    typeof(int),
                                                                                                    typeof(AddFields),
                                                                                                    new PropertyMetadata(12));

        public static readonly DependencyProperty FieldsProperty = DependencyProperty.Register(nameof(Fields),
                                                                                                    typeof(ObservableCollection<ModeloItemField>),
                                                                                                    typeof(AddFields),
                                                                                                    new PropertyMetadata(new ObservableCollection<ModeloItemField>()));


        public string TextAdd
        {
            get { return (string)GetValue(TextAddProperty); }
            set { SetValue(TextAddProperty, value); }
        }

        public string TextRemove
        {
            get { return (string)GetValue(TextRemoveProperty); }
            set { SetValue(TextRemoveProperty, value); }
        }

        public string TextName
        {
            get { return (string)GetValue(TextNameProperty); }
            set { SetValue(TextNameProperty, value); }
        }

        public string TextValue
        {
            get { return (string)GetValue(TextValueProperty); }
            set { SetValue(TextValueProperty, value); }
        }

        public string TextChecked
        {
            get { return (string)GetValue(TextCheckedProperty); }
            set { SetValue(TextCheckedProperty, value); }
        }


        public int MaxField
        {
            get { return (int)GetValue(MaxFieldProperty); }
            set { SetValue(MaxFieldProperty, value); }
        }

        public ObservableCollection<ModeloItemField> Fields
        {
            get { return (ObservableCollection<ModeloItemField>)GetValue(FieldsProperty); }
            set { SetValue(FieldsProperty, value); }
        }
            


        public AddFields()
        {
            InitializeComponent();

        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if(Fields.Count >= MaxField) { return; }
            Fields.Add(new ModeloItemField()
            {
                Index = Fields.Count + 1,
            });

        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {

            if (Fields.Count == 0) return;
            Fields.RemoveAt(Fields.Count - 1);
        }
    }
    public class ModeloItemField
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Checked { get; set; }
        public int Index { get; set; }

    }
}
