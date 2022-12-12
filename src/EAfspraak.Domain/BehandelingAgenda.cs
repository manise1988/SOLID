using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class BehandelingAgenda
    {

        public Specialist Specialist { get; set; }

           public Werkdag Werkdag { get; set; }

        public Time BeginTime { get; set; }
        public Time EndTime { get; set; }
        public BehandelingAgenda(Specialist sepecialist, Werkdag werkdag, Time beginTime, Time endTime)
        {

            Specialist = sepecialist;
            Werkdag = werkdag;
            BeginTime = beginTime;
            EndTime = endTime;

        }
    }

   
}
