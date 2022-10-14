using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public  class Behandeling
    {
        private string name;
        private string durationTime; 
        private bool isVerwijsbriefNodig;
        public string Name { get { return this.name; } }
        public string DurationTime { get { return durationTime; } }
        public bool IsVerwijsbriefNodig { get { return this.isVerwijsbriefNodig; } }
        public Behandeling(string name, string durationTime, bool isVerwijsbriefNodig)
        {
            this.name = name;
            this.durationTime = durationTime;
            this.isVerwijsbriefNodig = isVerwijsbriefNodig;



        }
    }
}
