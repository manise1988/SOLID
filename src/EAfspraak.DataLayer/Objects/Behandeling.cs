using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class Behandeling:ClassBase
    {
        public string Name { get; set; }
        public int BehandelingTimePerMin { get; set; }
       
        public int CategoryId { get; set; }

        public Behandeling(string name, int behandelingTimePerMin, int CategoryId)
        {
            Name = name;
            BehandelingTimePerMin = behandelingTimePerMin;
          
        }
    }
}
