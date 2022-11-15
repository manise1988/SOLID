using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class BehandelingAgenda
    {

        private Specialist specialist;

        public Specialist Specialist { get { return specialist; } set { specialist = value; } }

        private Werkdag werkdag;
        public Werkdag Werkdag { get { return werkdag; } set { werkdag = value; } }

        private Time beginTime;
        public Time BeginTime { get { return beginTime; } }
        private Time endTime;
        public Time EndTime { get { return endTime; } }
        public BehandelingAgenda(Specialist sepecialist, Werkdag werkdag, Time beginTime, Time endTime)
        {

            specialist = sepecialist;
            this.werkdag = werkdag;
            this.beginTime = beginTime;
            this.endTime = endTime;

        }
    }

    public enum Werkdag
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5
    }
}
