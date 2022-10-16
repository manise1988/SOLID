using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class Brief
    {
        private long bsn;
        public long Bsn { get { return bsn; } }

        private DateTime registerDate;
        public DateTime RegisterDate { get { return this.registerDate; } }

        private string categoryName;
        public string CategoryName { get { return this.categoryName; } }

        private string behandelingName;
        public string BehandelingName { get { return this.behandelingName; } }

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

        private long specialistBSN;
        public long SpecialistBSN { get { return this.specialistBSN; } }

        private string centrumName;
        public string CentrumName { get { return this.centrumName; } }

        public Brief(long bsn,string categoryName, string behandelingName, string details,
            string briefSoort,string briefStatus,DateTime registerDate,DateTime behandelingDatum,
            string beginTime,long specialistBSN, string centrumName)
        {
            this.bsn = bsn;
            this.categoryName = categoryName;
            this.behandelingName = behandelingName;
            this.details = details;
            this.briefSoort= briefSoort;
            this.briefStatus =briefStatus ;
            this.registerDate = registerDate;
            this.behandelingDatum = behandelingDatum;
            this.beginTime = beginTime;
            this.specialistBSN = specialistBSN;
            this.centrumName = centrumName;

        }


    }
}
