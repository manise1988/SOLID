using EAfspraak.DataLayer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer
{
    public static class FileContext
    {
        public static List<Behandeling> Behandelingen { get; set; }  
        public static List<Centrum> Centrums { get; set; }

        public static List<Specialist> Spesialisten { get; set; }
        public static List<BehandelingMogelijkheid> BehandelingCentrumSpecialisten { get; set; }

        public static List<Patiënt> Patiënten { get; set; }

        public static List<Behandeling> Behandeling { get; set; }
        public static List<VerwijsBrief> VerwijsBrief { get; set; }

        
    }
}
