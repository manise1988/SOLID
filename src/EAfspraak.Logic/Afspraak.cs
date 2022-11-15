using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public enum AfspraakStatus
    {
        InBehandeling,
        Close
    }
    public class Afspraak
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

        private DateTime behandelingDatum;
        public DateTime BehandelingDatum { get { return behandelingDatum; } }
        private Time beginTime;
        public Time BeginTime { get { return beginTime; } }

        private string details;
        public string Details { get { return details; } }

        private Specialist specialist;
        public Specialist Specialist { get { return specialist; } }

        private Patiënt patiënt;
        public Patiënt Patiënt { get { return patiënt; } }



        //public Afspraak(Category category, Behandeling behandeling, string details)
        //{

        //    this.category = category;
        //    this.behandeling = behandeling;
        //    this.afspraakStatus = AfspraakStatus.InBehandeling;
        //    this.registerDate = DateTime.Now;
        //    this.details = details;


        //}

        public Afspraak(Category category, Behandeling behandeling, string details,
           AfspraakStatus afspraakStatus, DateTime registerDate, DateTime behandelingDatum,
           Time beginTime, Specialist specialist, Patiënt patiënt)
        {

            this.category = category;
            this.behandeling = behandeling;
            this.details = details;
            this.afspraakStatus = afspraakStatus;
            this.registerDate = registerDate;
            this.behandelingDatum = behandelingDatum;
            this.beginTime = beginTime;
            this.specialist = specialist;
            this.patiënt = patiënt;


        }
    }
}
