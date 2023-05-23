using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ServidorBot.src.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para BarraPrincipal.xaml
    /// </summary>
    public partial class BarraPrincipal : UserControl
    {

        public static readonly DependencyProperty MaximizeProperty = DependencyProperty.Register(nameof(Maximize),
                                                                                  typeof(bool),
                                                                                  typeof(BarraPrincipal),
                                                                                  new PropertyMetadata(true));

        public static readonly DependencyProperty MinimizeProperty = DependencyProperty.Register(nameof(Minimize),
                                                                                  typeof(bool),
                                                                                  typeof(BarraPrincipal),
                                                                                  new PropertyMetadata(true));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title),
                                                                                  typeof(string),
                                                                                  typeof(BarraPrincipal),
                                                                                  new PropertyMetadata(""));

        public static readonly DependencyProperty WindowProperty = DependencyProperty.Register(nameof(Window),
                                                                                  typeof(Window),
                                                                                  typeof(BarraPrincipal),
                                                                                  new PropertyMetadata(null));
        public bool Maximize
        {
            get => (bool)GetValue(MaximizeProperty);
            set => SetValue(MaximizeProperty, value);
        }
        public bool Minimize
        {
            get => (bool)GetValue(MinimizeProperty);
            set => SetValue(MinimizeProperty, value);
        }
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public Window Window
        {
            get => (Window)GetValue(WindowProperty);
            set => SetValue(WindowProperty, value);
        }



        public BarraPrincipal()
        {
            InitializeComponent();

        }

        private void window_Movible(object sender, MouseButtonEventArgs e)
        {
            if (Window == null) { throw new Exception("No hay ventana para arrastrar, Window=\"{Binding ElementName=NombreDeLaVentana}\""); }

            if (e.LeftButton == MouseButtonState.Pressed) Window.DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window.Close();
        }

        private void Max_Click(object sender, RoutedEventArgs e)
        {
            Window.WindowState = WindowState.Maximized;
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            Window.WindowState = WindowState.Minimized;
        }
    }
}
