using EAfspraak.DataLayer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Contracts
{
    public interface IBehandelingService
    {

        public  List<Behandeling> GetData();
        public List<Behandeling> GetData(int categoryId);

        
    }
}
