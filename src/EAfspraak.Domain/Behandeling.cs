using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Behandeling
    {
        private string name;
        private Time durationTime;
        public string Name { get { return name; } }
        public Time DurationTime { get { return durationTime; } }

        private bool isVerwijsbriefNodig;
        public bool IsVerwijsbriefNodig { get { return isVerwijsbriefNodig; } }
        public Behandeling(string name, Time durationTime, bool isVerwijsbriefNodig)
        {
            this.name = name;
            this.durationTime = durationTime;
            this.isVerwijsbriefNodig = isVerwijsbriefNodig;



        }
    }
}
