using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{


    public enum BriefStatus
    {

        Open,
        Close
    }
    public class VerwijsBrief
    {

        private DateTime registerDate;
        public DateTime RegisterDate { get { return registerDate; } }

        private Category category;
        public Category Category { get { return category; } }

        private Behandeling behandeling;
        public Behandeling Behandeling { get { return behandeling; } }

        private BriefStatus briefStatus;
        public BriefStatus BriefStatus
        {
            get { return briefStatus; }
            set { briefStatus = value; }
        }


        private string details;
        public string Details { get { return details; } }



        public VerwijsBrief(Category category, Behandeling behandeling, string details)
        {

            this.category = category;
            this.behandeling = behandeling;
            briefStatus = BriefStatus.Open;
            registerDate = DateTime.Now;
            this.details = details;


        }

        public VerwijsBrief(Category category, Behandeling behandeling, string details,
           BriefStatus briefStatus, DateTime registerDate)
        {

            this.category = category;
            this.behandeling = behandeling;
            this.details = details;
            this.briefStatus = briefStatus;
            this.registerDate = registerDate;
        }
        public void CloseBriefStatus()
        {
            briefStatus = BriefStatus.Close;
        }
        public void OpenBriefStatus()
        {
            briefStatus = BriefStatus.Open;
        }
    }
}
