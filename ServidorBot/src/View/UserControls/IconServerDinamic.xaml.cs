using ServidorBot.src.View.Clases;
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

namespace ServidorBot.src.View.UserControls
{

    public partial class IconServerDinamic : UserControl
    {

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text),
                                                                                           typeof(string),
                                                                                           typeof(IconServerDinamic),
                                                                                           new PropertyMetadata(""));

        public static readonly DependencyProperty BackgroundLineProperty = DependencyProperty.Register(nameof(BackgroundLine),
                                                                                           typeof(Brush),
                                                                                           typeof(IconServerDinamic),
                                                                                           new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty BackgroundIconProperty = DependencyProperty.Register(nameof(BackgroundIcon),
                                                                                           typeof(Brush),
                                                                                           typeof(IconServerDinamic),
                                                                                           new PropertyMetadata(Brushes.Pink));

        public static readonly DependencyProperty SelectProperty = DependencyProperty.Register(nameof(Select),
                                                                                           typeof(bool),
                                                                                           typeof(IconServerDinamic),
                                                                                           new PropertyMetadata(false, ChangedSelect));


        public static readonly DependencyProperty VisiblePathProperty = DependencyProperty.Register(nameof(VisiblePath),
                                                                                             typeof(bool),
                                                                                             typeof(IconServerDinamic),
                                                                                             new PropertyMetadata(false));

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command",
                                                                                                typeof(ICommand),
                                                                                                typeof(IconServerDinamic),
                                                                                                new PropertyMetadata(null));

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter",
                                                                                                  typeof(object),
                                                                                                  typeof(IconServerDinamic));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Brush BackgroundLine
        {
            get { return (Brush)GetValue(BackgroundLineProperty); }
            set { SetValue(BackgroundLineProperty, value); }
        }

        public Brush BackgroundIcon
        {
            get { return (Brush)GetValue(BackgroundIconProperty); }
            set { SetValue(BackgroundIconProperty, value); }
        }

        public bool Select
        {
            get { return (bool)GetValue(SelectProperty); }
            set { SetValue(SelectProperty, value); }
        }
        public bool VisiblePath
        {
            get { return (bool)GetValue(VisiblePathProperty); }
            set { SetValue(VisiblePathProperty, value); }
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

        private readonly Storyboard StoryboardEntradaMouseOverFalse;
        private readonly Storyboard StoryboardSalidaMouseOverFalse;

        private readonly Storyboard StoryboardEntradaMouseOverTrue;
        private readonly Storyboard StoryboardSalidaMouseOverTrue;

        private readonly Storyboard StoryboardSalidaSelect;
        private readonly Storyboard StoryboardEntradaSelect;

        private static readonly List<IconServerDinamic> items = new();
        private bool MouseOver;

        public IconServerDinamic()
        {
            InitializeComponent();

            StoryboardEntradaMouseOverFalse = new Storyboard();
            StoryboardSalidaMouseOverFalse = new Storyboard();

            StoryboardEntradaMouseOverTrue = new Storyboard();
            StoryboardSalidaMouseOverTrue = new Storyboard();

            StoryboardSalidaSelect = new Storyboard();
            StoryboardEntradaSelect = new Storyboard();

            Duration duration = new Duration(TimeSpan.FromMilliseconds(200));

            ClasesDeAnimacionesForFrames.BorderSizeXY(0, 5, 0, 30, duration, border_animati, StoryboardEntradaMouseOverFalse);
            ClasesDeAnimacionesForFrames.BorderSizeXY(5, 0, 30, 0, duration, border_animati, StoryboardSalidaMouseOverFalse);
            ClasesDeAnimacionesForFrames.BorderCornerRadius(30, 20, duration, border_interno, StoryboardEntradaMouseOverFalse);
            ClasesDeAnimacionesForFrames.BorderCornerRadius(20, 30, duration, border_interno, StoryboardSalidaMouseOverFalse);

            ClasesDeAnimacionesForFrames.BorderSizeY(10, 30, duration, border_animati, StoryboardEntradaMouseOverTrue);
            ClasesDeAnimacionesForFrames.BorderSizeY(30, 10, duration, border_animati, StoryboardSalidaMouseOverTrue);

            //Animacion cuando es selecionado el objeto sin Over
            ClasesDeAnimacionesForFrames.BorderSizeXY(0, 5, 0, 10, duration, border_animati, StoryboardEntradaSelect);
            ClasesDeAnimacionesForFrames.BorderSizeXY(5, 0, 10, 0, duration, border_animati, StoryboardSalidaSelect);
            ClasesDeAnimacionesForFrames.BorderCornerRadius(30, 20, duration, border_interno, StoryboardEntradaSelect);
            ClasesDeAnimacionesForFrames.BorderCornerRadius(20, 30, duration, border_interno, StoryboardSalidaSelect);

            items.Add(this);
        }

        /// <summary>
        /// Este metodo verifica la propiedad Select de otros elementos de la lista "items"
        /// si la propiedad Select es true cambiara a false, con este nos aseguramos que 
        /// un elemento de todos que esten en list sea True y los demas False.
        /// </summary>
        /// <param name="thisElement">El elemento que va a estar true.</param>
        public static void ParseFalse(IconServerDinamic thisElement)
        {
            foreach (var item in items)
            {
                if (item != thisElement)
                {
                    if (!item.MouseOver && item.Select)
                    {
                        item.Select = false;
                    }
                }
            }
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            if (Select == false)
            {
                Select = true;
                ParseFalse(this);


                if (Command != null && Command.CanExecute(null))
                {
                    Command.Execute(CommandParameter);
                }
            }

        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            MouseOver = true;
            if (Select == false)
            {
                StoryboardEntradaMouseOverFalse.Begin();
            }
            else
            {
                StoryboardEntradaMouseOverTrue.Begin();
            }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            MouseOver = false;
            if (Select == false)
            {
                StoryboardSalidaMouseOverFalse.Begin();
            }
            else
            {
                StoryboardSalidaMouseOverTrue.Begin();
            }
        }

        public static void SelectFristItem()
        {
            if (items.Count > 0)
            {
                var elem = items[0];
                elem.Select = true;
            }
        }

        public void AnimatedChangedSelectedToTrue()
        {

            if (MouseOver == true)
            {
                
            }
            else
            {
                StoryboardEntradaSelect.Begin();
            }

        }

        public void AnimatedChangedSelectedToFalse()
        {
            if (MouseOver == true)
            {
                
            }
            else
            {
                StoryboardSalidaSelect.Begin();
            }
        }

        private static void ChangedSelect(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is IconServerDinamic iconServer)
            {
                bool newValue = (bool)e.NewValue;
                if (newValue)
                {
                    iconServer.AnimatedChangedSelectedToTrue();
                }
                else
                {
                    iconServer.AnimatedChangedSelectedToFalse();
                }

            }
        }
    }
}
