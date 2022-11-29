
using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Afspraak:IAfspraak
    {
        private DateTime registerDate;
        public DateTime RegisterDate { get { return registerDate; } }

        private Category category;
        public Category Category { get { return category; } }

        private Behandeling behandeling;
        public Behandeling Behandeling { get { return behandeling; } }

        private AfspraakStatus afspraakStatus;
        public AfspraakStatus AfspraakStatus
        {
            get { return afspraakStatus; }
            set { afspraakStatus = value; }
        }

        private DateTime datum;
        public DateTime Datum { get { return datum; } }
        private Time beginTime;
        public Time BeginTime { get { return beginTime; } }

        private string details;
        public string Details { get { return details; } }

        private Specialist specialist;
        public Specialist Specialist { get { return specialist; } }

        private Patiënt patiënt;
        public Patiënt Patiënt { get { return patiënt; } }


        public Afspraak(Category category, Behandeling behandeling, string details,
           AfspraakStatus afspraakStatus, DateTime registerDate, DateTime datum,
           Time beginTime, Specialist specialist, Patiënt patiënt)
        {

            this.category = category;
            this.behandeling = behandeling;
            this.details = details;
            this.afspraakStatus = afspraakStatus;
            this.registerDate = registerDate;
            this.datum = datum;
            this.beginTime = beginTime;
            this.specialist = specialist;
            this.patiënt = patiënt;


        }

        public bool IsAfspraakInBehandeling()
        {
            if(afspraakStatus == AfspraakStatus.InBehandeling)
                return true;
            else
                return false;
        }
       
    }
}
