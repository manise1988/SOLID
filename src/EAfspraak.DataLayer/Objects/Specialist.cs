using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class Specialist:PersonBase
    {
        public Category Category { get; set; }
       
        public Specialist(long bsn,string name,Category category)
        {
            base.BSN = bsn;
            base.Name = name;
            this.Category = category;
            
           
        }

    }


}
