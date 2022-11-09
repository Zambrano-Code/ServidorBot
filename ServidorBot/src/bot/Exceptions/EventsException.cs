using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot.Exceptions
{
    public class EventsException: Exception
    {

        public static string ELEMENT_EXISTS = "0001";
        public static string ERROR_INSERT = "0002";

        public string EventExetioCode { get; private set; }

        public EventsException(string message, string eventExetioCode):base(message)
        {
            EventExetioCode = eventExetioCode;
        }
    }
}
