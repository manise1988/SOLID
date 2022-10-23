using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Domain
{
    public  class Huisarts:PersonBase
    {
        private DateTime birthday;
        public DateTime Birthday { get { return this.birthday; } }

        public Huisarts(long bsn, string firstName, string lastName, DateTime birthday)
        {
            base.BSN = bsn;
            base.FirstName = firstName;
            base.LastName = lastName;
            this.birthday = birthday;
          

        }
    }
}
