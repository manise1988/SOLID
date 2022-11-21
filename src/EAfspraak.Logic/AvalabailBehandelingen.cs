using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class AvalabailBehandelingen : IAvailable
    {
         public List<Behandeling> BehandelingList {
            get;
            set;
        }

        public bool IsAvailable(string name)
        {
            if (BehandelingList.Where(x => x.Name == name).Any())
                return true;
            else
                return false;
        }

     
    }
}
