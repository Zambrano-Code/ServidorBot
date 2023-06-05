using System;
using System.Reactive.Concurrency;
using System.Threading;
using System.Threading.Tasks;


namespace bot.acciones
{
    public class EventoRepetitive
    {
        public string name { get; private set; }
        public DateTime starTime { get; private set; }
        public TimeSpan timeToRepeat { get; private set; }
        public string zonehour { get; private set; }
        public Action evento { get; private set; }
        public DateTime ScheduledTime { get; private set; }

        private TimeSpan temp { get; set; }

        private Timer? timer { get; set; }
        

        public EventoRepetitive(string name, DateTime starTime, TimeSpan timeToRepeat, string zonehour , Action evento)
        {
            this.name = name;
            this.starTime = starTime;
            this.timeToRepeat = timeToRepeat;
            this.zonehour = zonehour;
            this.evento = evento;


        }

        public async void Run()
        {
            validar();
            Console.WriteLine("Este evento se enviara en: " + temp.ToString());
            StartRelog(temp, timeToRepeat);
        }


        public void Stop()
        {
            if(timer != null)
            {
                timer.Dispose();
     
            }
        }
        private void validar()
        {
            //if (starTime == null) throw new ArgumentException("The starTime parameter cannot be a null value.");
            if (zonehour == null) throw new ArgumentException("The zonehour parameter cannot be a null value.");
            if (evento == null) throw new ArgumentException("The evento parameter cannot be a null value.");
            

            DateTime timeTemp;
            if (zonehour.ToLower() == "utc")
            {
                timeTemp = DateTime.UtcNow;
            }
            else if (zonehour == "local")
            {
                timeTemp = DateTime.Now;
            }
            else throw new ArgumentException("Invalid argument value ( utc or local).");

            temp = starTime.Subtract(timeTemp);

            if (timeToRepeat > TimeSpan.Zero)
            {
                while (temp < TimeSpan.Zero)
                {
                    temp = temp.Add(timeToRepeat);
                }

            }else if (timeToRepeat == TimeSpan.Zero && temp < TimeSpan.Zero)
            {
                throw new Exception("The timeToRepeates is zero so the starTime must be after the current time.");
            }

        }


        

        /// <summary>
        /// Este metodo al ejecuta un evento a la hora fijada, repitira la accion evento() cada cierto tiempo (time2), si es que le agrego un valor
        /// </summary>
        /// <param name="time1">Tiempo que se va a ejcutar la accion</param>
        /// <param name="time2">Tiempo a repetir la accion</param>
        /// <returns></returns>
        private void StartRelog(TimeSpan time1, TimeSpan time2)
        {
            var timeR = time2 == TimeSpan.Zero ? Timeout.InfiniteTimeSpan : time2;
            ScheduledTime = DateTime.Now.Add(time1);

            timer = new Timer( _ =>
            {
                evento();
                ScheduledTime = DateTime.Now.Add(time2);
            }, null, time1, timeR);
        }


    }

}

