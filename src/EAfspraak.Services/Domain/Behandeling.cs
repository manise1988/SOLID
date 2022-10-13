using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Domain
{
    public class Behandeling
    {
        private string name;
        private Time durationTime;
        public string Name { get { return this.name; } }
        public Time DurationTime { get { return durationTime; } }
        public Behandeling(string name, Time durationTime)
        {
            this.name = name;
            this.durationTime = durationTime;
           

                  
        }
    }
}
