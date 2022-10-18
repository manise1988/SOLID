using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class VerwijsBrief
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
        private string details;
        public string Details { get { return this.details; } }


        public VerwijsBrief(long bsn,string categoryName, string behandelingName, string details
            ,string briefStatus,DateTime registerDate)
        {
            this.bsn = bsn;
            this.categoryName = categoryName;
            this.behandelingName = behandelingName;
            this.details = details;

            this.briefStatus =briefStatus ;
            this.registerDate = registerDate;


        }


    }
}
