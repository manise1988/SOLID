using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Entities
{
    public class ReserveTime
    {
        public int Id { get; set; }
        public int VerwijsBriefId { get; set; }
        public int BehandelingCentrumSpecialistId { get; set; }

        public DateTime DateTime { get; set; }
        public string BegintTime { get; set; }
        public string EindTime { get; set; }

       

    }
}
