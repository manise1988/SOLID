using EAfspraak.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer
{
    public static class FileContext
    {
        public static List<Behandeling> Behandelings { get; set; }  
        public static List<BehandelingCentrum> BehandelingCentrums { get; set; }

        public static List<BriefProces> BriefProcessen { get; set; }
        public static List<Patiënt> Patiënteb { get; set; }

        public static List<Behandeling> Behandeling { get; set; }
        public static List<VerwijsBrief> VerwijsBrief { get; set; }




    }
}
