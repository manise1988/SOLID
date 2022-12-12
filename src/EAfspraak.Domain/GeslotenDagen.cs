using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EAfspraak.Domain
{
    public class GeslotenDagen 
    {
        public DateTime Datum { get; private set; }
        public string Details { get; private set; }
        public GeslotenDagen(DateTime datum, string details)
        {
            Datum = datum;
            Details = details;
        }
    }
}
