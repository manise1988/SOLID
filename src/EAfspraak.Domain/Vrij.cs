using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EAfspraak.Domain
{
    public class Vrij 
    {
        public DateTime Datum { get; private set; }
        public string Details { get; private set; }
        public VrijType VrijType { get; private set; }
        public Vrij(DateTime datum, string details, VrijType vrijType)
        {
            Datum = datum;
            Details = details;
            VrijType = vrijType;
            VrijType = VrijType;
        }
    }
}
