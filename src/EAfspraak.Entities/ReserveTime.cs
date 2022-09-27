using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DomainLayer
{
    public class ReserveTime
    {
        public int Id { get; set; }
        public VerwijsBrief VerwijsBrief { get; set; }
        public BehandelingMogelijkheid BehandelingMogelijkheid { get; set; }

        public DateTime DateTime { get; set; }
        public string BegintTime { get; set; }
        public string EindTime { get; set; }

       

    }


}
