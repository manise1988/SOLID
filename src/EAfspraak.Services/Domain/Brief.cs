using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Domain
{
    public enum BriefStatus
    {
        Open,
        AanDeBeurt,
        Closed
    }

    public enum BriefSoort
    {
        Verwijsbrief,
        Brief
    }
    public class Brief
    {

        private DateTime registerDate;
        public DateTime RegisterDate { get { return this.registerDate; } }

        private Category category;
        public Category Category { get { return this.Category; } }

        private Behandeling behandeling;
        public Behandeling Behandeling { get { return this.behandeling; } }

        private BriefStatus briefStatus;
        public BriefStatus BriefStatus { get { return this.briefStatus; } 
            set {this.briefStatus = value;} }

        private DateTime behandelingDatum;
        public DateTime BehandelingDatum { get{ return this.behandelingDatum; } }
        private Time beginTime;
        public Time BegintTime { get { return this.beginTime; } }
        // public Time EindTime { get; set; }

        private string details;
        public string Details { get { return this.details; } }

        private BriefSoort briefSoort;
        public BriefSoort BriefSoort { get { return this.briefSoort; } }

        private Specialist specialist;
        public Specialist Specialist { get { return this.specialist; } }

        private Centrum centrum;
        public Centrum Centrum { get { return this.centrum; } }

        public Brief(Category category ,Behandeling behandeling, string details, BriefSoort briefSoort)
        {
            
            this.category = category;
            this.behandeling = behandeling;
            this.briefStatus = BriefStatus.Open;
            this.registerDate = DateTime.Now;
            this.details = details;
            this.briefSoort = briefSoort;
           
        }

        public Brief(Category category, Behandeling behandeling, string details,
           BriefSoort briefSoort, BriefStatus briefStatus, DateTime registerDate, DateTime behandelingDatum,
           Time beginTime, Specialist specialist, Centrum centrum)
        {

            this.category = category;
            this.behandeling = behandeling;
            this.details = details;
            this.briefSoort = briefSoort;
            this.briefStatus = briefStatus;
            this.registerDate = registerDate;
            this.behandelingDatum = behandelingDatum;
            this.beginTime = beginTime;
            this.specialist = specialist;
            this.centrum = centrum;

        }
    }
}
