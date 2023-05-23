using System;

namespace ServidorBot.src.View.Model
{
    public class CrearEventoM
    {
        public string NameEvento { get; set; }
        public DateTime DateInit { get; set; }
        public TimeSpan TimeRepeat{ get; set; }
        public bool UTC { get; set; }

    }
}
