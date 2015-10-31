using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GsmUse
{
    public class Call
    {
        public DateTime Date { get; private set; }
        public string Number { get; private set; }
        public uint Duration { get; private set; }

        public Call(DateTime dateTime, string number, uint duration)
        {
            this.Date = dateTime;
            this.Number = number;
            this.Duration = duration;
        }

        public override string ToString()
        {
            return string.Format("{0}; {1}; duration: {2}s.", this.Date, this.Number, this.Duration);
        }
    }
}
