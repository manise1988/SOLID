using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Specialist : Persoon
    {
        private Category category;
        public Category Category { get { return category; } }

        public Specialist(long bsn, string firstName, string lastName, Category category)
        {
            BSN = bsn;
            FirstName = firstName;
            LastName = lastName;
            this.category = category;


        }

    }


}
