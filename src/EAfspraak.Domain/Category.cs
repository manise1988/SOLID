using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Interfaces;

namespace EAfspraak.Domain
{
    public class Category
    {

        private string name;
        public string Name { get { return name; } }

        private List<IBehandeling> behandelingen;
        public List<IBehandeling> Behandelingen { get { return behandelingen; } }
        public Category(string name)
        {
            this.name = name;
            behandelingen = new List<IBehandeling>();



        }

        public void AddBehandeling(IBehandeling behandeling)
        {
            behandelingen.Add(behandeling);
        }
    }
}
