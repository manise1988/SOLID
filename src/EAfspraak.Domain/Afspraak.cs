
using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Afspraak
    {
        public IBehandeling Behandeling { get; }
        public DateTime Datum { get; }
        public Time BehandelingTime { get; }
        public Specialist Specialist { get; }
        public Patiënt Patiënt { get; }



        public Afspraak(IBehandeling behandeling,
            DateTime datum,
           Time beginTime, Specialist specialist, Patiënt patiënt)
        {

            Behandeling = behandeling;
           
            Datum = datum;
            BehandelingTime = beginTime;
            Specialist = specialist;
            Patiënt = patiënt;
   

        }

        
       
       
    }
}
