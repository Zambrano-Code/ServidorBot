using bot.acciones;
using Discord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
using static System.Net.Mime.MediaTypeNames;

namespace ServidorBot.src.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para EventoRepetitivoUserControl.xaml
    /// </summary>
    public partial class EventoRepetitivoUserControl : UserControl
    {

        public static readonly DependencyProperty EventMensajeProperty = DependencyProperty.Register(nameof(EventMensaje),
                                                                                   typeof(MensageRepetitive),
                                                                                   typeof(EventoRepetitivoUserControl),
                                                                                   new PropertyMetadata(null, changedEventMensaje));

        public MensageRepetitive EventMensaje
        {
            get => (MensageRepetitive)GetValue(EventMensajeProperty);
            set => SetValue(EventMensajeProperty, value);
        }

        public ModelEventRepeat Model { get; set; } = new ModelEventRepeat();

        private static void changedEventMensaje(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EventoRepetitivoUserControl EventRepeat)
            {
                MensageRepetitive msgR = (MensageRepetitive)e.NewValue;
                var model = EventRepeat.Model;

                model.NameEvent = msgR.Name;
                model.Active = msgR.Active is true ? "Activo" : "Inactivo";
                model.Channel = ((IMessageChannel)msgR.Channel).Name;
                model.CreateFor = msgR.CreateFor.Username;
                model.TimeActive = msgR.TimeActive.ToString("yyyy/MM/dd HH:mm:ss");
                model.TimeToRepeat = msgR.TimeToRepeat.ToString();
                model.ZoneHour = msgR.ZoneHour.ToUpper();
                model.DateCreate = msgR.DateCreate.ToString("yyyy/MM/dd HH:mm:ss");

                Task.Run(async () =>
                {
                    while (true)
                    {
                        var nowTime = DateTime.Now;
                        var tR = msgR.ScheduledTime - nowTime;
                        model.TimeFromActive = tR;

                        await Task.Delay(TimeSpan.FromSeconds(1));
                    }
                });

            }
        }
       
        public EventoRepetitivoUserControl()
        {
            InitializeComponent();

        }
    }

    public class ModelEventRepeat : INotifyPropertyChanged
    {
        private string nameEvent = "";
        private string active = "";
        private string channel = "";
        private string createFor = "";
        private string timeActive = "";
        private string timeToRepeat = "";
        private string zoneHour = "";
        private string dateCreate = "";
        private TimeSpan timeFromActive;

        public string NameEvent
        {
            get { return nameEvent; }
            set { nameEvent = value; OnPropertyChanged(nameof(NameEvent)); }
        }
        public string Active
        {
            get => active;
            set { active = value; OnPropertyChanged(nameof(Active)); }
        }

        public string Channel
        {
            get => channel;
            set { channel = value; OnPropertyChanged(nameof(Channel)); }
        }
        public string CreateFor
        {
            get => createFor;
            set { createFor = value; OnPropertyChanged(nameof(CreateFor)); }
        }
        public string TimeActive
        {
            get => timeActive;
            set { timeActive = value; OnPropertyChanged(nameof(TimeActive)); }
        }

        public string TimeToRepeat
        {
            get => timeToRepeat;
            set { timeToRepeat = value; OnPropertyChanged(nameof(TimeToRepeat)); }
        }

        public string ZoneHour
        {
            get => zoneHour;
            set { zoneHour = value; OnPropertyChanged(nameof(ZoneHour)); }
        }

        public string DateCreate
        {
            get => dateCreate;
            set { dateCreate = value; OnPropertyChanged(nameof(DateCreate)); }
        }

        public TimeSpan TimeFromActive
        {
            get => timeFromActive;
            set { timeFromActive = value; OnPropertyChanged(nameof(TimeFromActive)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
