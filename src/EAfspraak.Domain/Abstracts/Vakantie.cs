using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Abstracts
{
    public abstract class Vakantie
    {
        public DateTime Datum { get; set; }
        public string Details { get; set; }
    }
}
