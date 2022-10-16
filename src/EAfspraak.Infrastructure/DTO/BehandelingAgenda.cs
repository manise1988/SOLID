using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class BehandelingAgenda
    {
        private long bsnSpecialist;

        public long BSNSpecialist { get { return this.bsnSpecialist; }  }

        private string werkdag;
        public string Werkdag { get { return this.werkdag; } }

        private string beginTime;
        public string BeginTime { get { return this.beginTime; } }

        private string endTime;
        public string  EndTime { get { return this.endTime; } }

        private string centrumName;
        public string CentrumName { get { return this.centrumName; } }
        public BehandelingAgenda(long bsnSpecialist, string werkdag, string  beginTime, string endTime,string centrumName)
        {

            this.bsnSpecialist = bsnSpecialist;
            this.werkdag = werkdag;
            this.beginTime = beginTime;
            this.endTime = endTime;
            this.centrumName = centrumName;

        }
    }
}
