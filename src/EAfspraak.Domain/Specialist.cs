using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Abstracts;

namespace EAfspraak.Domain
{
    public class Specialist : Persoon
    {
        public Category Category { get; set; }

        public Specialist(long bsn, string firstName, string lastName, Category category)
        {
            BSN = bsn;
            FirstName = firstName;
            LastName = lastName;
            Category = category;

        }

      

    }


}
