using Discord;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Crmf;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Lógica de interacción para PickTime.xaml
    /// </summary>
    public partial class PickTime : UserControl
    {
        #region Propiedades
        public ModelListScrollAll HorasSlots { get; } = new ModelListScrollAll(0, 23);
        public ModelListScrollAll MinutosSlots { get; set; } = new ModelListScrollAll(0, 59);
        public ModelListScrollAll SegundoSlots { get; set; } = new ModelListScrollAll(0, 59);
        

        public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(PickTime));

        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(PickTime));

        public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register("Foreground", typeof(Brush), typeof(PickTime));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(UserControl));

        public Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }
        public Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }
        public Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }



        #endregion


        public PickTime()
        {
            Background = Brushes.Gold;
            BorderBrush = Brushes.Red;
            Foreground = Brushes.Black;

            InitializeComponent();

            //Horas.SelectedItem = 0;
            //Minutos.SelectedItem = 5;
            //Segundos.SelectedItem = 0;

        }

        private void Grid_MouseWheelH(object sender, MouseWheelEventArgs e)
        {
            //Console.WriteLine(e.Delta);

            if (e.Delta > 0)
            {
                HorasSlots.Up();
                return;
            }

            if (e.Delta < 0)
            {
                HorasSlots.Down();
                return;
            }


        }
        private void Grid_MouseWheelM(object sender, MouseWheelEventArgs e)
        {
            //Console.WriteLine(e.Delta);

            if (e.Delta > 0)
            {
                MinutosSlots.Up();
                return;
            }

            if (e.Delta < 0)
            {
                MinutosSlots.Down();
                return;
            }


        }
        private void Grid_MouseWheelS(object sender, MouseWheelEventArgs e)
        {
            //Console.WriteLine(e.Delta);

            if (e.Delta > 0)
            {
                SegundoSlots.Up();
                return;
            }

            if (e.Delta < 0)
            {
                SegundoSlots.Down();
                return;
            }


        }


        private void BuHSlot_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            HorasSlots.Run((string)button.Content);
        }
        private void BuMSlot_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            MinutosSlots.Run((string)button.Content);
        }
        private void BuSSlot_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            SegundoSlots.Run((string)button.Content);
        }

        private void OpenPopup_Click(object sender, RoutedEventArgs e)
        {
            Popup_Picker.IsOpen = true;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Text = $"{HorasSlots.Select}:{MinutosSlots.Select}:{SegundoSlots.Select}";
            Popup_Picker.IsOpen = false;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Popup_Picker.IsOpen = false;
        }

        private void Now_Click(object sender, RoutedEventArgs e)
        {
            var tim = DateTime.Now;
            fijateHora(tim.Hour, tim.Minute, tim.Second);

        }

        private void fijateHora(int horas, int minutos, int segundos)
        {
            HorasSlots.Select = horas.ToString();
            MinutosSlots.Select = minutos.ToString();
            SegundoSlots.Select = segundos.ToString();
        }
    }

    public class ModelListScrollAll : ViewModelBase
    {
        #region Slot
        private int slot3;
        private int slot2;
        private int slot1;
        private int slot0;
        private int slot_1;
        private int slot_2;
        private int slot_3;

        public string Slot3
        {
            get
            {
                return TransformTwoValue(slot3);
            }
            set
            {
                slot3 = int.Parse(value);
                OnPropertyChanged(nameof(Slot3));
            }
        }
        public string Slot2
        {
            get
            {
                return TransformTwoValue(slot2);
            }
            set
            {
                slot2 = int.Parse(value);
                OnPropertyChanged(nameof(Slot2));
            }
        }
        public string Slot1
        {
            get
            {
                return TransformTwoValue(slot1);
            }
            set
            {
                slot1 = int.Parse(value);
                OnPropertyChanged(nameof(Slot1));

            }
        }
        public string Slot0
        {
            get
            {
                return TransformTwoValue(slot0);
            }
            set
            {
                slot0 = int.Parse(value);
                OnPropertyChanged(nameof(Slot0));

            }
        }
        public string Slot_1
        {
            get
            {
                return TransformTwoValue(slot_1);
            }
            set
            {
                slot_1 = int.Parse(value);
                OnPropertyChanged(nameof(Slot_1));

            }
        }
        public string Slot_2
        {
            get
            {
                return TransformTwoValue(slot_2);
            }
            set
            {
                slot_2 = int.Parse(value);
                OnPropertyChanged(nameof(Slot_2));

            }
        }
        public string Slot_3
        {
            get
            {
                return TransformTwoValue(slot_3);
            }
            set
            {
                slot_3 = int.Parse(value);
                OnPropertyChanged(nameof(Slot_3));

            }
        }
        #endregion

        private int NumInit;
        private int NumEnd;
        public ModelListScrollAll(int NumInit, int NumEnd)
        {
            this.NumInit = NumInit;
            this.NumEnd = NumEnd;

            slot3 = NumInit + 3;
            slot2 = NumInit + 2;
            slot1 = NumInit + 1;
            slot0 = NumInit;
            slot_1 = NumEnd;
            slot_2 = NumEnd - 1;
            slot_3 = NumEnd - 2;

        }

        public void Up(int i = 1)
        {
            Slot3 = sum(slot3, i).ToString();
            Slot2 = sum(slot2, i).ToString();
            Slot1 = sum(slot1, i).ToString();
            Slot0 = sum(slot0, i).ToString();
            Slot_1 = sum(slot_1, i).ToString();
            Slot_2 = sum(slot_2, i).ToString();
            Slot_3 = sum(slot_3, i).ToString();
        }

        public void Down(int i = 1)
        {
            Slot3 = rest(slot3, i).ToString();
            Slot2 = rest(slot2, i).ToString();
            Slot1 = rest(slot1, i).ToString();
            Slot0 = rest(slot0, i).ToString();
            Slot_1 = rest(slot_1, i).ToString();
            Slot_2 = rest(slot_2, i).ToString();
            Slot_3 = rest(slot_3, i).ToString();

        }

        private int sum(int num, int icr)
        {
            if (num == NumEnd)
            {
                return NumInit;
            }

            var temp = num + icr;
            if (temp > NumEnd)
            {
                return NumInit + (temp - NumEnd);
            }

            return temp;
        }

        private int rest(int num, int icr)
        {
            if (num == NumInit)
            {
                return NumEnd;
            }

            var temp = num - icr;
            if (temp < NumInit)
            {
                return NumEnd + (NumInit + temp);
            }

            return temp;
        }

        public void Run(string num)
        {
            var num2 = int.Parse(num);

            if (slot3 == num2) { Up(); Up(); Up(); }
            if (slot2 == num2) { Up(); Up(); }
            if (slot1 == num2) { Up(); }
            if (slot_1 == num2) { Down(); }
            if (slot_2 == num2) { Down(); Down(); }
            if (slot_3 == num2) { Down(); Down(); Down(); }
        }

        public string Select
        {
            set
            {
                var i = int.Parse(value);
                Slot3 = getSlot(i, 3).ToString();
                Slot2 = getSlot(i, 2).ToString();
                Slot1 = getSlot(i, 1).ToString();
                Slot0 = value;
                Slot_1 = getSlot(i, -1).ToString();
                Slot_2 = getSlot(i, -2).ToString();
                Slot_3 = getSlot(i, -3).ToString();

            }
            get { return Slot0; }
        }

        private int getSlot(int sl, int cant)
        {
            sl = sl + cant;

            if(sl > NumEnd)
            {
                return sl - NumEnd;
            }

            if (sl < NumInit)
            {
                return (sl+1) + NumEnd;
            }

            return sl;
        }

        private string TransformTwoValue(int num)
        {
            if(num <= 9  && num >= 0)
            {
                return $"0{num}";
            }
            return num.ToString();
        }

    }

}
