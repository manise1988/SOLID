using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class Specialist
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
        private Category category;
        public Category Category { get { return this.category; } }

        public Specialist(long bsn, string firstName, string lastName, Category category)
        {
            this.bsn = bsn;
            this.firstName = firstName;
            this.lastName = lastName;
            this.category = category;


        }
    }
}
