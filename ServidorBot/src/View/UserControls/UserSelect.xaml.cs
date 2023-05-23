using ServidorBot.src.View.Clases;
using ServidorBot.src.View.Converter;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace ServidorBot.src.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para UserSelect.xaml
    /// </summary>
    public partial class UserSelect : UserControl
    {

        public static readonly DependencyProperty ActiveProperty = DependencyProperty.Register(nameof(Active),
                                                                                            typeof(bool),
                                                                                            typeof(UserSelect),
                                                                                            new PropertyMetadata(false));


        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register(nameof(UserName),
                                                                                            typeof(string),
                                                                                            typeof(UserSelect),
                                                                                            new PropertyMetadata(""));

        public static readonly DependencyProperty UrlIconProperty = DependencyProperty.Register(nameof(UrlIcon),
                                                                                            typeof(string),
                                                                                            typeof(UserSelect),
                                                                                            new PropertyMetadata("", UrlChanged));

        public static readonly DependencyProperty ColorBrushProperty = DependencyProperty.Register(nameof(ColorBrush),
                                                                                            typeof(SolidColorBrush),
                                                                                            typeof(UserSelect),
                                                                                            new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty VisibleIconProperty = DependencyProperty.Register(nameof(VisibleIcon),
                                                                                            typeof(Visibility),
                                                                                            typeof(UserSelect),
                                                                                            new PropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty BackgroundIconProperty = DependencyProperty.Register(nameof(BackgroundIcon),
                                                                                            typeof(Brush),
                                                                                            typeof(UserSelect),
                                                                                            new PropertyMetadata(MetodosDeAceso.HexToSolidColorBrush("#5865F2")));

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command",
                                                                                                typeof(ICommand),
                                                                                                typeof(UserSelect),
                                                                                                new PropertyMetadata(null));

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter",
                                                                                                  typeof(object),
                                                                                                  typeof(UserSelect));
        public bool Active
        {
            get { return (bool)GetValue(ActiveProperty); }
            set { SetValue(ActiveProperty, value); }
        }

        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public string UrlIcon
        {
            get { return (string)GetValue(UrlIconProperty); }
            set { SetValue(UrlIconProperty, value); }
        }
        public SolidColorBrush ColorBrush
        {
            get { return (SolidColorBrush)GetValue(ColorBrushProperty); }
            set { SetValue(ColorBrushProperty, value); }
        }

        public Visibility VisibleIcon
        {
            get { return (Visibility)GetValue(VisibleIconProperty); }
            set { SetValue(VisibleIconProperty, value); }
        }
        
        public Brush BackgroundIcon
        {
            get { return (Brush)GetValue(BackgroundIconProperty); }
            set { SetValue(BackgroundIconProperty, value); }
        }


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly List<UserSelect> items = new();

        private Color primaryColor = MetodosDeAceso.StringToColor("#C1C1C1");
        private Color secondaryColor = MetodosDeAceso.StringToColor("#4486F2");
        private Duration duracion = new Duration(TimeSpan.FromMilliseconds(150));
        private Storyboard animacionEntrada = new Storyboard();
        private Storyboard animacionSalida = new Storyboard();
        public UserSelect()
        {


            InitializeComponent();

            ClasesDeAnimacionesForFrames.TextBockColor(primaryColor, secondaryColor, duracion, textB, animacionEntrada);
            ClasesDeAnimacionesForFrames.TextBockColor(secondaryColor, primaryColor, duracion, textB, animacionSalida);

            //El primer elemento de la lista estara activo dando la animacion de vinculacion
            if (items.Count == 0) { ActionClick(); }
            items.Add(this);
        }


        public static void ParseFalse(UserSelect thisElement)
        {
            foreach (var item in items)
            {
                if (item.Active && item != thisElement)
                {
                    item.Active = false;
                    item.Begin();
                }
            }
        }



        private static void UrlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UserSelect userSelect)
            {
                if (e.NewValue is string text)
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        userSelect.BackgroundIcon = MetodosDeAceso.GetImageBrushFromUrl(text);
                        userSelect.VisibleIcon = Visibility.Hidden;
                    }
                }
            }
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ActionClick();
        }

        private void ActionClick()
        {
            if (Active) return;
            Active = !Active;

            if (Command != null && Command.CanExecute(null))
            {
                Command.Execute(CommandParameter);
            }

            ParseFalse(this);
            Begin();
        }

        private async void Begin()
        {
            if (!Active)
            {
                for (int i = 1; i <= 39; i += 2)
                {
                    metod(i);
                    await Task.Delay(1);
                }
            }
            else
            {
                for (int i = 39; i >= 1; i -= 2)
                {
                    metod(i);
                    await Task.Delay(1);
                }
            }
        }

        private void metod(int num)
        {
            switch (num)
            {
                case 1: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 0  V 70 C 19 58 8 55 0 55 Z"); break;
                case 2: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 1  V 69 C 19 58 8 55 0 55 Z"); break;
                case 3: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 2  V 68 C 19 58 8 55 0 55 Z"); break;
                case 4: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 3  V 67 C 19 58 8 55 0 55 Z"); break;
                case 5: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 4  V 66 C 19 58 8 55 0 55 Z"); break;
                case 6: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 5  V 65 C 19 58 8 55 0 55 Z"); break;
                case 7: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 6  V 64 C 19 58 8 55 0 55 Z"); break;
                case 8: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 7  V 63 C 19 58 8 55 0 55 Z"); break;
                case 9: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 8  V 62 C 19 58 8 55 0 55 Z"); break;

                case 10: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 9  V 61 C 19 58 8 55 0 55 Z"); break;
                case 11: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 10 V 60 C 19 58 8 55 0 55 Z"); break;
                case 12: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 11 V 59 C 19 58 8 55 0 55 Z"); break;
                case 13: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 12 V 58 C 19 58 8 55 0 55 Z"); break;
                case 14: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 12 20 13 V 57 C 19 58 8 55 0 55 Z"); break;
                case 15: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 13 20 14 V 56 C 19 57 8 55 0 55 Z"); break;
                case 16: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 13 20 15 V 55 C 19 57 8 55 0 55 Z"); break;
                case 17: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 14 20 16 V 54 C 19 56 8 55 0 55 Z"); break;
                case 18: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 14 20 17 V 53 C 19 56 8 55 0 55 Z"); break;
                case 19: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 15 20 18 V 52 C 19 55 8 55 0 55 Z"); break;

                case 20: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 15 20 19 V 51 C 19 55 8 55 0 55 Z"); break;
                case 21: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 16 20 20 V 50 C 19 54 8 55 0 55 Z"); break;
                case 22: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 16 20 21 V 49 C 19 54 8 55 0 55 Z"); break;
                case 23: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 17 20 22 V 48 C 19 53 8 55 0 55 Z"); break;
                case 24: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 17 20 23 V 47 C 19 53 8 55 0 55 Z"); break;
                case 25: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 18 20 24 V 46 C 19 52 8 55 0 55 Z"); break;
                case 26: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 18 20 25 V 45 C 19 52 8 55 0 55 Z"); break;
                case 27: elem.Data = Geometry.Parse("M 0 15 C 8 15 19 19 19 25 V 45 C 19 51 8 55 0 55 Z"); break;
                case 28: elem.Data = Geometry.Parse("M 0 15 C 8 15 18 19 18 25 V 45 C 18 51 8 55 0 55 Z"); break;
                case 29: elem.Data = Geometry.Parse("M 0 15 C 8 15 17 19 17 25 V 45 C 17 51 8 55 0 55 Z"); break;

                case 30: elem.Data = Geometry.Parse("M 0 15 C 8 15 16 19 16 25 V 45 C 16 51 8 55 0 55 Z"); break;
                case 31: elem.Data = Geometry.Parse("M 0 15 C 8 15 15 19 15 25 V 45 C 15 51 8 55 0 55 Z"); break;
                case 32: elem.Data = Geometry.Parse("M 0 15 C 8 15 14 19 14 25 V 45 C 14 51 8 55 0 55 Z"); break;
                case 33: elem.Data = Geometry.Parse("M 0 15 C 8 15 13 19 13 25 V 45 C 13 51 8 55 0 55 Z"); break;
                case 34: elem.Data = Geometry.Parse("M 0 15 C 8 15 12 19 12 25 V 45 C 12 51 8 55 0 55 Z"); break;
                case 35: elem.Data = Geometry.Parse("M 0 15 C 8 15 11 19 11 25 V 45 C 11 51 8 55 0 55 Z"); break;
                case 36: elem.Data = Geometry.Parse("M 0 15 C 8 15 10 19 10 25 V 45 C 10 51 8 55 0 55 Z"); break;
                case 37: elem.Data = Geometry.Parse("M 0 15 C 8 15 9  19 9  25 V 45 C 9  51 8 55 0 55 Z"); break;
                case 38: elem.Data = Geometry.Parse("M 0 15 C 8 15 8  19 8  25 V 45 C 8  51 8 55 0 55 Z"); break;

            }
        }


        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            animacionEntrada.Begin();
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            animacionSalida.Begin();
        }
    }
}
