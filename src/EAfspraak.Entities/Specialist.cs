using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DomainLayer
{
    public class Specialist:PersonBase
    {
       
        public string name { get; set; }
        public Specialist(int bsn,string name)
        {
            base.BSN = bsn;
            this.name = name;
        }

    }


}
