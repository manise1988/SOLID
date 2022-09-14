using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Entities
{
    public class BehandelingCentrum
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int BehandelingId { get; set; }
    }
}
