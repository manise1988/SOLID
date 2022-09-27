using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Entities
{
    public class Patiënt
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
        public int BSN { get; set; }    
        public string EmailAddress { get; set; }    
        public string Address { get; set; }

         
    }
}
