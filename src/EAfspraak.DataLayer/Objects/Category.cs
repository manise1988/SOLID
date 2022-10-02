using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public  class Category:ClassBase
    {
        public string Name { get; set; }
        public List<Behandeling> Behandelingen { get; set; }
        public Category(string name)
        {
            Name = name;
            Behandelingen = new List<Behandeling>();
            base.Id = Guid.NewGuid().GetHashCode();

            
        }

        public void AddBehandeling(Behandeling behandeling)
        {
            Behandelingen.Add(behandeling);
        }
    }
}
