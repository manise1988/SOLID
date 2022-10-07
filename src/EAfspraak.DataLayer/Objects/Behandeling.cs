using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class Behandeling
    {
        public string Name { get; set; }
        public string DurationTime { get; set; }
        public Behandeling(string name, string durationTime)
        {
            Name = name;
            DurationTime = durationTime;
           

                  
        }
    }
}
