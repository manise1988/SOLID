using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public enum BriefStatus
    {
        Open,
        Expaired,
        AanDeBeurt,
        Closed
    }
    public class VerwijsBrief:ClassBase
    {
        public Patiënt Patiënt { get; set; }
        public DateTime RegisterDate { get; }
        public Behandeling Behandeling { get; set; }
        public BriefStatus BriefStatus { get; set; }
        public BehandelingMogelijkheid BehandelingMogelijkheid { get; set; }
        public DateTime BehandelingDatum { get; set; }
        public string BegintTime { get; set; }
        public string EindTime { get; set; }

        public string Details { get; set; }

        public VerwijsBrief(Patiënt patënt,Behandeling behandeling, string details)
        {
            Patiënt = patënt;
            Behandeling = behandeling;
            BriefStatus = BriefStatus.Open;
            RegisterDate = DateTime.Now;
            Details = details;
        }
    }
}
