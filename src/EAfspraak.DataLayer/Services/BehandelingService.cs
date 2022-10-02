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
        
        public List<Behandeling> GetData()
        {
            var behandelings = new List<Behandeling>();
            foreach (var item in DataContext.Categories.ToList())
                behandelings.AddRange(item.Behandelingen.ToList());

            return behandelings;
        }

        public List<Behandeling> GetData(int categoryId)
        {
            var behandelings = new List<Behandeling>();
            for(int i = 0; i < DataContext.Categories.Count; i++)
                if (DataContext.Categories[i].Id == categoryId)
                {
                    behandelings.AddRange(DataContext.Categories[i].Behandelingen.ToList());
                    return behandelings.ToList();
                }

            return behandelings;
        }

        
    }
}
