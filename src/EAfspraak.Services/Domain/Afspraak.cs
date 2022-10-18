using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Domain
{
    public enum AfspraakStatus
    {
        Open,
        InBehandeling,
        Closed
    }
    public class Afspraak
    {
        private DateTime registerDate;
        public DateTime RegisterDate { get { return this.registerDate; } }

        private Category category;
        public Category Category { get { return this.category; } }

        private Behandeling behandeling;
        public Behandeling Behandeling { get { return this.behandeling; } }

        private AfspraakStatus afspraakStatus;
        public AfspraakStatus AfspraakStatus
        {
            get { return this.afspraakStatus; }
            set { this.afspraakStatus = value; }
        }

        private DateTime behandelingDatum;
        public DateTime BehandelingDatum { get { return this.behandelingDatum; } }
        private Time beginTime;
        public Time BegintTime { get { return this.beginTime; } }

        private string details;
        public string Details { get { return this.details; } }

        private Specialist specialist;
        public Specialist Specialist { get { return this.specialist; } }

        private Patiënt patiënt;
        public Patiënt Patiënt { get { return this.patiënt; } }



        public Afspraak(Category category, Behandeling behandeling, string details)
        {

            this.category = category;
            this.behandeling = behandeling;
            this.afspraakStatus = AfspraakStatus.Open;
            this.registerDate = DateTime.Now;
            this.details = details;
  

        }

        public Afspraak(Category category, Behandeling behandeling, string details,
           AfspraakStatus afspraakStatus, DateTime registerDate, DateTime behandelingDatum,
           Time beginTime, Specialist specialist)
        {

            this.category = category;
            this.behandeling = behandeling;
            this.details = details;
            this.afspraakStatus = afspraakStatus;
            this.registerDate = registerDate;
            this.behandelingDatum = behandelingDatum;
            this.beginTime = beginTime;
            this.specialist = specialist;


        }
    }
}
