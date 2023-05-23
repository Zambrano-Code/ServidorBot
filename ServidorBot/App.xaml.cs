using bot;
using ServidorBot.src.View.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;

namespace ServidorBot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Bot Bot { get; private set; }

        public App()
        {
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bot = new Bot();
            await Bot.MainAsyn();

        }

        public static void CrearWindow()
        {
            if (Bot.IsActive == false)
            {
                MessageBox.Show("El bot no está activo. Por favor, intenta de nuevo más tarde.");
                return;
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                MainWindow MainWindow = new MainWindow();
                MainWindow.Show();
            });

        }

    }
}
