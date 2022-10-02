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

        public VerwijsBrief MaakAfspraak(VerwijsBrief verwijsBrief);


    }
}
