using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DomainLayer
{
    public class Centrum
    {
        public string Name { get; set; }  
        public string Address { get; set; }
  
        public Centrum(string name, string address)
        {
            Name = name;
        }
    }
}
