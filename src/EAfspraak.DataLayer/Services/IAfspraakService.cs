using EAfspraak.DataLayer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Services
{
    public interface IAfspraakService
    {

        public VerwijsBrief MaakAfspraak();
        public void RegisterVerwijsBrief(Patiënt patiënt, VerwijsBrief verwijsBrief);

       
    }
}
