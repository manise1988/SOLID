using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EAfspraak.Domain
{
    public class Verlof :Abstracts.Vakantie
    {
      
        public Verlof(DateTime datum, string details)
        {
            base.Datum = datum;
            base.Details = details;
        }
    }
}
