using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Logic.Domain
{


    public enum BriefStatus
    {
       
        Open,
        Close
    }
    public class VerwijsBrief
    {

        private DateTime registerDate;
        public DateTime RegisterDate { get { return this.registerDate; } }

        private Category category;
        public Category Category { get { return this.category; } }

        private Behandeling behandeling;
        public Behandeling Behandeling { get { return this.behandeling; } }

        private BriefStatus briefStatus;
        public BriefStatus BriefStatus { get { return this.briefStatus; } 
            set {this.briefStatus = value;} }

      
        private string details;
        public string Details { get { return this.details; } }

       

        public VerwijsBrief(Category category ,Behandeling behandeling, string details)
        {
            
            this.category = category;
            this.behandeling = behandeling;
            this.briefStatus = BriefStatus.Open;
            this.registerDate = DateTime.Now;
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
            this.briefStatus = BriefStatus.Close;
        }
        public void OpenBriefStatus()
        {
            this.briefStatus = BriefStatus.Open;
        }
    }
}
