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

        public string Name { get; }

       public List<IBehandeling> Behandelingen { get; }
        public Category(string name)
        {
            Name = name;
            Behandelingen = new List<IBehandeling>();



        }

        public void AddBehandeling(IBehandeling behandeling)
        {
            Behandelingen.Add(behandeling);
        }
    }
}
