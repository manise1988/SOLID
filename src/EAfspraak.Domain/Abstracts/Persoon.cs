using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Abstracts
{
    public abstract class Persoon
    {
        public long BSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
