using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public abstract class PersonBase : ClassBase
    {
        public long BSN { get; set; }
        public string Name { get; set; }
    }
}
