using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class Specialist:PersonBase
    {
       
        public string name { get; set; }
        public List<Behandeling> Behandelings { get; set; }
        public Specialist(int bsn,string name)
        {
            base.BSN = bsn;
            this.name = name;
        }

    }


}
