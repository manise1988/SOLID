using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class BehandelingAgenda
    {
        private Specialist specialist;

        public Specialist Specialist { get { return this.specialist; } set { this.specialist = value; } }

        private string werkdag;
        public string Werkdag { get { return this.werkdag; } set { this.werkdag = value; } }

        private string beginTime;
        public string BeginTime { get { return this.beginTime; } }

        private string endTime;
        public string  EndTime { get { return this.endTime; } }
        public BehandelingAgenda(Specialist specialist, string werkdag, string  beginTime, string endTime)
        {

            this.specialist = specialist;
            this.werkdag = werkdag;
            this.beginTime = beginTime;
            this.endTime = endTime;

        }
    }
}
