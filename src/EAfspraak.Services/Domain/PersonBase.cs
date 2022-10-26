using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Domain
{
    public abstract class Persoon 
    {
        private long bsn;
        public long BSN {
            get { return this.bsn; }
            set { this.bsn = value; } }
        private string firstName;
        
        public string FirstName {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        private string lastName;
        public string LastName {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
    }
}
