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

        private Behandeling[] behandelingen;
        public Behandeling[] Behandelingen { get { return this.behandelingen; } }
        public Category(string name,Behandeling[] behandelingen)
        {
            this.name = name;
            this.behandelingen = behandelingen;
        }

       
    }
}
