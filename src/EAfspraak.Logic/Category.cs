using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Category
    {

        private string name;
        public string Name { get { return name; } }

        private List<Behandeling> behandelingen;
        public List<Behandeling> Behandelingen { get { return behandelingen; } }
        public Category(string name)
        {
            this.name = name;
            behandelingen = new List<Behandeling>();



        }

        public void AddBehandeling(Behandeling behandeling)
        {
            behandelingen.Add(behandeling);
        }
    }
}
