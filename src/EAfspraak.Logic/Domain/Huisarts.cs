using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Logic.Domain
{
    public  class Huisarts:Persoon
    {
        private string birthday;
        public string Birthday { get { return this.birthday; } }

        public Huisarts(long bsn, string firstName, string lastName, string birthday)
        {
            base.BSN = bsn;
            base.FirstName = firstName;
            base.LastName = lastName;
            this.birthday = birthday;
          

        }
    }
}
