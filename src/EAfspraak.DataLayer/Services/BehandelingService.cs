using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.DataLayer.Contracts;
using EAfspraak.Entities;

namespace EAfspraak.DataLayer.Services
{
    public class BehandelingService : IBehandelingService
    {
        public List<Behandeling> getData()
        {
            var behandelings = FileContext.Behandeling;
            
            return behandelings;
        }
    }
}
