using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class RegularAfspraak : IAfspraak
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

        private List<DateTime> behandelingDatums;
        public List<DateTime> BehandelingDatums { get { return behandelingDatums; } }

        private Time beginTime;
        public Time BeginTime { get { return beginTime; } }

        private string details;
        public string Details { get { return details; } }

        private Specialist specialist;
        public Specialist Specialist { get { return specialist; } }

        private Patiënt patiënt;
        public Patiënt Patiënt { get { return patiënt; } }

        private int aantalBehandelingen;
        public int AantaalBehandelingen { get { return aantalBehandelingen; } }
        public RegularAfspraak(Category category, Behandeling behandeling, string details,
           AfspraakStatus afspraakStatus, DateTime registerDate,int aantal, DateTime datum,
           List<DateTime> behandelingDatums, Time beginTime, Specialist specialist, Patiënt patiënt)
        {

            this.category = category;
            this.behandeling = behandeling;
            this.details = details;
            this.afspraakStatus = afspraakStatus;
            this.registerDate = registerDate;
            this.datum = datum;
            this.behandelingDatums = behandelingDatums;
            this.aantalBehandelingen= aantal;
            this.beginTime = beginTime;
            this.specialist = specialist;
            this.patiënt = patiënt;


        }


        public bool IsValid()
        {
            if(afspraakStatus == AfspraakStatus.InBehandeling)
                return true;
            else
                return false;
        }
      
    }
}
