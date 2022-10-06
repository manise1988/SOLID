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
       
        public Specialist(long bsn,string firstName, string lastName,Category category)
        {
            base.BSN = bsn;
            base.FirstName = firstName;
            base.LastName = lastName;
            this.Category = category;
            
           
        }

    }


}
