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
        private string birthday;
        public string Birthday { get { return birthday; } }

        public Huisarts(long bsn, string firstName, string lastName, string birthday)
        {
            BSN = bsn;
            FirstName = firstName;
            LastName = lastName;
            this.birthday = birthday;


        }
    }
}
