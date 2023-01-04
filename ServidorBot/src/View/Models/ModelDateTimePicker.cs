using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ServidorBot.src.View.Models
{
    public class ModelDateTimePicker : ViewModelBase
    {
        private DateTime _date;

        public DateTime Date
        {
            set
            {
                _date = new DateTime(year: value.Year, month: value.Month, day: value.Day, hour: _date.Hour, minute: _date.Minute, second: _date.Second);
                OnPropertyChanged(nameof(Text));
            }
        }

        public TimeSpan Time
        {
            set
            {
                _date = new DateTime(year: _date.Year, month: _date.Month, day: _date.Day, hour: value.Hours, minute: value.Minutes, second: value.Seconds);
                OnPropertyChanged(nameof(Text));
            }
        }

        public string Text
        {
            get
            {
                //Console.WriteLine(_date.ToString());
                if (_date != new DateTime())
                {
                    return _date.ToString("dd/MM/yyyy H:mm:ss");
                }
                return "";
            }


        }

        public DateTime DateTime
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Text));
            }
        }
    }
}
