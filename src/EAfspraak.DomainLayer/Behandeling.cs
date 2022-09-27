using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Entities
{
    public class Behandeling:EntityBase
    {
        public string Name { get; set; }
        public int BehandelingTimePerMin { get; set; }
     
    }
}
