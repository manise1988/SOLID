using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class Afspraak
    {
        private string categoryName;
        public string CategoryName { get { return categoryName; } }

        private string behandelingName;
        public string BehandelingName { get { return this.behandelingName; } }


        private string behandelingDatum;
        public string BehandelingDatum { get { return this.behandelingDatum; } }
        private string beginTime;
        public string BeginTime { get { return this.beginTime; } }

        private string afspraakStatus;
        public string AfspraakStatus { get { return this.afspraakStatus; } }

        private long patientBSN;
        public long PatientBSN { get { return this.patientBSN; } }

        private long specialistBSN;
        public long SpecialistBSN { get { return this.specialistBSN; } }

        private string centrumName;
        public string CentrumName { get { return this.centrumName; } }


        public Afspraak( string categoryName, string behandelingName,
                  string afspraakStatus, string behandelingDatum,
                  string beginTime, long patientBSN, long specialistBSN, string centrumName)
        {
            this.patientBSN = patientBSN;
            this.categoryName = categoryName;
            this.behandelingName = behandelingName;
            this.afspraakStatus = afspraakStatus;
            this.behandelingDatum = behandelingDatum;
            this.beginTime = beginTime;
            this.specialistBSN = specialistBSN;
            this.centrumName = centrumName;

        }
    }
}
