using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class Persoon
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
        private string birthday;
        public string Birthday { get { return this.birthday; } }

        private string emailAddress;
        public string EmailAddress { get { return this.emailAddress; } }
        private string address;
        public string Address { get { return this.address; } }

        private string role;
        public string Role { get { return this.role; } }
        public Persoon(long bsn, string firstName, string lastName, string birthday, string emailAddress, string address,string role)
        {
            this.bsn = bsn;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birthday;
            this.emailAddress = emailAddress;
            this.address = address;
            this.role = role;
            

        }
    }

  
}
