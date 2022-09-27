using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DomainLayer
{
    public class BehandelingMogelijkheid
    {
        
        public Behandeling Behandeling { get; set; }
        public Centrum Centrum { get; set; }  
        public Specialist Sepecialist { get; set; }

        public Werkdag werkdag { get; set; }

        public string BegintTime { get; set; }
        public string EindTime { get; set; }

    }

    public enum Werkdag
    {
        maandag,
        dinsdag,
        woensdag,
        donderdag,
        vrijdag,
        zaterdag
    }
}
