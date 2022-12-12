using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Abstracts;

namespace EAfspraak.Domain
{
    public class Huisarts : Persoon
    {
        public string Birthday { get; }

        public Huisarts(long bsn, string firstName, string lastName, string birthday)
        {
            BSN = bsn;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;


        }
    }
}
