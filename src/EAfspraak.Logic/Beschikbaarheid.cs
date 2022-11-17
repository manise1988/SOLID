using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Beschikbaarheid
    {
        public Time Time { get; set; }

        public string Date { get; set; }

        public Specialist Specialist { get; set; }
        public Beschikbaarheid(Time time, DateTime date, Specialist specialist)
        {
            Time = time;
            Date = date.ToShortDateString();
            Specialist = specialist;
        }
    }
}
