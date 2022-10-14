using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class Brief
    {

        private DateTime registerDate;
        public DateTime RegisterDate { get { return this.registerDate; } }

        private Category category;
        public Category Category { get { return this.Category; } }

        private Behandeling behandeling;
        public Behandeling Behandeling { get { return this.behandeling; } }

        private string briefStatus;
        public string BriefStatus
        {
            get { return this.briefStatus; }
           
        }

        private DateTime behandelingDatum;
        public DateTime BehandelingDatum { get { return this.behandelingDatum; } }
        private string beginTime;
        public string BegintTime { get { return this.beginTime; } }
 
        private string details;
        public string Details { get { return this.details; } }

        private string briefSoort;
        public string BriefSoort { get { return this.briefSoort; } }

        private Specialist specialist;
        public Specialist Specialist { get { return this.specialist; } }

        private Centrum centrum;
        public Centrum Centrum { get { return this.centrum; } }

        public Brief(Category category, Behandeling behandeling, string details,
            string briefSoort,string briefStatus,DateTime registerDate,DateTime behandelingDatum,
            string beginTime,Specialist specialist,Centrum centrum)
        {

            this.category = category;
            this.behandeling = behandeling;
            this.details = details;
            this.briefSoort= briefSoort;
            this.briefStatus =briefStatus ;
            this.registerDate = registerDate;
            this.behandelingDatum = behandelingDatum;
            this.beginTime = beginTime;
            this.specialist = specialist;
            this.centrum = centrum;

        }


    }
}
