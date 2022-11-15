using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Logic.Domain
{
    public class Specialist:Persoon
    {
        private Category category;
        public Category Category { get { return this.category; } }
       
        public Specialist(long bsn,string firstName, string lastName,Category category)
        {
            base.BSN = bsn;
            base.FirstName = firstName;
            base.LastName = lastName;
            this.category = category;
            
           
        }

    }


}
