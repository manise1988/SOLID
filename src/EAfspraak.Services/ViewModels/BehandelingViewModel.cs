using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Domain
{
    public class BehandelingViewModel
    {
        private string name;
        private string durationTime;
        public string Name { get { return this.name; } }
        public string  DurationTime { get { return durationTime; } }

        private bool isVerwijsbriefNodig;
        public bool IsVerwijsbriefNodig { get { return this.isVerwijsbriefNodig; } }
        public BehandelingViewModel(string name, string durationTime,bool isVerwijsbriefNodig)
        {
            this.name = name;
            this.durationTime = durationTime;
            this.isVerwijsbriefNodig = isVerwijsbriefNodig;
           

                  
        }
    }
}
