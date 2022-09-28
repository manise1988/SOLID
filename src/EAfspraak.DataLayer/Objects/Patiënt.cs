using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class Patiënt: PersonBase 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string EmailAddress { get; set; }    
        public string Address { get; set; }

        public List<VerwijsBrief> VerwijsBrieven { get; set; }

        public Patiënt(int bsn,string firstName, string lastName, DateTime birthday, string emailAddress, string address)
        {
            base.BSN = bsn;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            EmailAddress = emailAddress;
            Address = address;
            base.Id = Guid.NewGuid().GetHashCode();
        }
    }
}
