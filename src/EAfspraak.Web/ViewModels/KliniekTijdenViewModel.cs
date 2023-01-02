
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Web.ViewModels
{
    public class KliniekTijdenViewModel
    {
        public string KliniekName { get; }
        public string KliniekDescription { get; }
        public long SpecialistBSN { get;}
        public string Date { get;  }
        public string AfspraakTime { get;}
        public KliniekTijdenViewModel(string kliniekName, string kliniekDescription,  long specialistBSN, string date, string afspraakTime)
        {
            KliniekName = kliniekName;
            KliniekDescription = kliniekDescription;
            SpecialistBSN = specialistBSN;
            Date = date;
            AfspraakTime = afspraakTime;
        }
    }
}
