using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Domain
{
    public class Agenda
    {
        public Time Time { get; set; }

        public string Date { get; set; }

        public Agenda(Time time, DateTime date)
        {
            Time = time;
            Date = date.ToShortDateString();
        }
    }
}
