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
    public class VerwijsBrief
    {
        public Patiënt Patiënt { get; set; }
        public DateTime RegisterDate { get; set; }
        public Behandeling Behandeling { get; set; }
        public BriefStatus BriefStatus { get; set; }
        public BehandelingMogelijkheid BehandelingMogelijkheid { get; set; }
        public DateTime BehandelingDatum { get; set; }
        public string BegintTime { get; set; }
        public string EindTime { get; set; }

        public VerwijsBrief(Patiënt patënt,Behandeling behandeling)
        {
            Patiënt = patënt;
            Behandeling = behandeling;
            BriefStatus = BriefStatus.Open;
            RegisterDate = DateTime.Now;
        }
    }
}
