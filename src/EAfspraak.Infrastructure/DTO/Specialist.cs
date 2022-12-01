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
        private string categoryName;
        public string CategoryName { get { return this.categoryName; } }

        private Vrij[] verlofs;
        public Vrij[] Verlofs { get { return this.verlofs; } }
        
        public Specialist(long bsn, string firstName, string lastName, string categoryName,
            Vrij[] verlofs)
        {
            this.bsn = bsn;
            this.firstName = firstName;
            this.lastName = lastName;
            this.categoryName = categoryName;
            this.verlofs = verlofs;


        }
    }
}
