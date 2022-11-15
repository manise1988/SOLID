using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Logic.Domain
{
    public  class Category
    {

        private string name;
        public string Name { get { return this.name; } }

        private List<Behandeling> behandelingen;
        public List<Behandeling> Behandelingen { get { return this.behandelingen; } }
        public Category(string name)
        {
            this.name = name;
            this.behandelingen = new List<Behandeling>();
           

            
        }

        public void AddBehandeling(Behandeling behandeling)
        {
            this.behandelingen.Add(behandeling);
        }
    }
}
