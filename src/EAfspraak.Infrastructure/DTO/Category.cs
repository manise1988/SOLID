using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class Category
    {
        private string name;
        public string Name { get { return this.name; } }
        
        
        public Category(string name)
        {
            
            this.name = name;
           
        }

       
    }
}
