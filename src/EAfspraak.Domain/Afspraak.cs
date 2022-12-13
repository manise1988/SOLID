
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
        public Category Category { get; }
        public IBehandeling Behandeling { get; }
        public AfspraakStatus AfspraakStatus{ get;}
        public DateTime Datum { get; }
        public Time BehandelingTime { get; }
        public Specialist Specialist { get; }
        public Patiënt Patiënt { get; }


        public Afspraak(Category category, IBehandeling behandeling,
           AfspraakStatus afspraakStatus,  DateTime datum,
           Time beginTime, Specialist specialist, Patiënt patiënt)
        {

            Category = category;
            Behandeling = behandeling;
            AfspraakStatus = afspraakStatus;
            Datum = datum;
            BehandelingTime = beginTime;
            Specialist = specialist;
            Patiënt = patiënt;


        }

        
        public bool IsAfspraakInBehandeling()
        {
            if(AfspraakStatus == AfspraakStatus.InBehandeling)
                return true;
            else
                return false;
        }
       
    }
}
