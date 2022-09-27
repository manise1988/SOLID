using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DomainLayer
{
    public class Behandeling
    {
        public string Name { get; set; }
        public int BehandelingTimePerMin { get; set; }

        public Behandeling(string name, int behandelingTimePerMin)
        {
            Name = name;
            BehandelingTimePerMin = behandelingTimePerMin;
        }
    }
}
