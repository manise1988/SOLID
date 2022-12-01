using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EAfspraak.Domain
{
    public class Vakantie :Abstracts.Vakantie
    {
        public Vakantie(DateTime datum, string details)
        {
            base.Datum = datum;
            base.Details = details;
        }
    }
}
