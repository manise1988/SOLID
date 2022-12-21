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

        public Category(string name, List<Behandeling> behandelingen)
        {
            Name = name;
            Behandelingen = new List<IBehandeling>();
            Behandelingen.AddRange(behandelingen);
           
            


        }
        public void AddBehandeling(IBehandeling behandeling)
        {
            Behandelingen.Add(behandeling);
        }
    }
}
