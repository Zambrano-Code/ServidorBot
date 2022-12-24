using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorBot.src.View.Models
{
    public class ModelDateTimePicker : ViewModelBase
    {
        private string _date;
        private string _time;
        private string _text;

        private int _length;

        public string Date
        {
            set
            {
                _date = value;
                Text = $"{value} {_time}";
                OnPropertyChanged(nameof(Date));
            }
        }
        public string Time
        {
            set
            {
                _time = value;
                Text = $"{_date} {value}";
                OnPropertyChanged(nameof(Time));
            }
        }
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        public int Length
        {
            get { return _length; }
            set { _length = value;}
        }
    }
}
