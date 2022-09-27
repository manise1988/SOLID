using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DomainLayer
{
    public enum BriefStatus
    {
        Active,
        Reserve,
        Doen,
        Expierd

    }
    public class VerwijsBrief
    {
         
        public Behandeling Behandeling { get; set; }
        public Patiënt Patiënt { get; set; }
        public DateTime RegisterDate { get; set; }
        public BriefStatus Status { get; set; }

    }
}
