using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Entities
{
    public class BriefProcess
    {
        public int Id { get; set; }
        public int VerwijsBriefId { get; set; }
        public int BehandelingCentumId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }

        public BriefStatus Status { get; set; }
    }
   
}
