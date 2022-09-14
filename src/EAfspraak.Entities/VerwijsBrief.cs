using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Entities
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
        public int Id { get; set; } 
        public int BehandelingId { get; set; }
        public int PatiëntId { get; set; }
        public DateTime RegisterDate { get; set; }

        public BriefStatus Status { get; set; }

    }
}
