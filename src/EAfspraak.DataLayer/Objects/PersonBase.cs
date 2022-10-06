using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public abstract class PersonBase 
    {
        public long BSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
