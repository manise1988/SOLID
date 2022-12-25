
using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Afspraak
    {
        [JsonConverter(typeof(ConcreteConverter<Behandeling>))]
        public IBehandeling Behandeling { get; set; }
        public DateTime Datum { get; set; }
        public Time BehandelingTime { get; set; }
        public Specialist Specialist { get; set; }
        public Patiënt Patiënt { get; set; }

        public Kliniek Kliniek { get; set; }

        public Afspraak(IBehandeling behandeling,
            DateTime datum,
           Time beginTime, Specialist specialist, Patiënt patiënt,Kliniek kliniek)
        {

            Behandeling = behandeling;
           
            Datum = datum;
            BehandelingTime = beginTime;
            Specialist = specialist;
            Patiënt = patiënt;
            Kliniek = kliniek;
   

        }

        public bool IsAfspraakInBehandeling()
        {
            DateTime currentDate =DateTime.Parse( DateTime.Now.ToShortDateString());
            if(Datum >=  DateTime.Now)
                return false;
            else
                return true;
        }


    }
}
