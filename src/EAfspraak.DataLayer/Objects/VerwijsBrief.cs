using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public enum BriefStatus
    {
        Open,
        AanDeBeurt,
        Closed
    }
    public class VerwijsBrief
    {
       
        public DateTime RegisterDate { get; }
        public Behandeling Behandeling { get; set; }
        public BriefStatus BriefStatus { get; set; }
        
        public DateTime BehandelingDatum { get; set; }
        public string BegintTime { get; set; }
        public string EindTime { get; set; }

        public string Details { get; set; }

        public VerwijsBrief(Behandeling behandeling, string details)
        {
            
            Behandeling = behandeling;
            BriefStatus = BriefStatus.Open;
            RegisterDate = DateTime.Now;
            Details = details;
           
        }

       
    }
}
