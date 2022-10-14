using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class Patiënt
    {
        private long bsn;
        public long BSN
        {
            get { return this.bsn; }

        }
        private string firstName;

        public string FirstName
        {
            get { return this.firstName; }

        }
        private string lastName;
        public string LastName
        {
            get { return this.lastName; }

        }
        private DateTime birthday;
        public DateTime Birthday { get { return this.birthday; } }

        private string emailAddress;
        public string EmailAddress { get { return this.emailAddress; } }
        private string address;
        public string Address { get { return this.Address; } }

        private Brief[] brieven;
        public Brief[] Brieven { get { return this.brieven; } }

        public Patiënt(long bsn, string firstName, string lastName, DateTime birthday, string emailAddress, string address,Brief[] brieven)
        {
            this.bsn = bsn;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birthday;
            this.emailAddress = emailAddress;
            this.address = address;
            this.brieven = brieven;

        }
    }

  
}
