using bot.acciones;
using bot.modelos;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace ServidorBot.src.View.Models
{
    public class ModeloEventoRepetitivoUserControl : ViewModelBase
    {
        private MensageRepetitive MensageRepe { get; set; }

        public string Name { get; set; }
        public string Status { get; set; }
        public string Channel { get; set; }
        public string Guild { get; set; }
        public string CreateFor { get; set; }
        private string _timeActive { get; set; }
        public string TimeActive
        {
            get
            {
                return _timeActive;
            }
            set
            {
                _timeActive = value;
                OnPropertyChanged(nameof(TimeActive));
            }
        }
        public string TimeToRepeat { get; set; }
        public string HoursActive { get; set; }
        public string DateCreate { get; set; }

        public ModeloEventoRepetitivoUserControl(MensageRepetitive MensageRepe)
        {
            this.MensageRepe = MensageRepe;

            Name = MensageRepe.name;
            Status = MensageRepe.Active == true ? "On" : "Off";
            Channel = ((IMessageChannel)MensageRepe.canal_envio).Name;
            Guild = MensageRepe.guild_envio.Name;
            CreateFor = MensageRepe.user_create.Username;
            TimeToRepeat = MensageRepe.time_to_repeat.ToString();
            HoursActive = MensageRepe.tiempo_envio.ToString("dd/mm/yyyy H:mm:ss ") + MensageRepe.zone_hour;
            DateCreate = MensageRepe.date_create.ToString("dd/mm/yyyy H:mm");

            runTimeToRepeat();

        }

        private static Timer aTimer = new Timer() { Interval = 1000, Enabled = true };
        private void runTimeToRepeat()
        {
            aTimer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            
            var a = timeForActive(MensageRepe.tiempo_envio, MensageRepe.time_to_repeat, MensageRepe.zone_hour);
            TimeActive = ((a.Days == 0 ? "00" : a.Days) + ":" +  (a.Hours == 0 ? "00" : a.Hours) +":"+ (a.Minutes == 0 ? "00" : a.Minutes) +":"+ (a.Seconds == 0 ? "00" : a.Seconds));

        }

        public static TimeSpan timeForActive(DateTime TimeInicio, TimeSpan TimeRepeat, string utc)
        {
            DateTime TimeNow = DateTime.Now;
            if (utc.ToLower() == "utc") TimeNow = DateTime.UtcNow;

            while(TimeInicio <= TimeNow)
            {
                TimeInicio += TimeRepeat;
            }

            TimeSpan tp = TimeInicio - TimeNow;
            return tp;
        }
    }


}
