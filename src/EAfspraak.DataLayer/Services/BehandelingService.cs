using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.DataLayer.Contracts;
using EAfspraak.DataLayer.Objects;

namespace EAfspraak.DataLayer.Services
{
    public class BehandelingService : IBehandelingService
    {
        public void Add(Behandeling behandeling)
        {
           // FileContext.Behandeling.Add(behandeling);
        }
        public List<Behandeling> GetData()
        {
            var behandelings = new List<Behandeling>();
            foreach (var item in DataContext.Categories.ToList())
                behandelings.AddRange(item.Behandelings.ToList());

            return behandelings;
        }
    }
}
