using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure.DTO
{
    public class Vrij
    {
        
        private string datum;
        public string Datum { get { return this.datum; } }

        private string datail;
        public string Datail { get { return this.datail; } }

        public Vrij( string datum, string datail)
        {
          
            this.datum = datum;
            this.datail = datail;
        }
    }
}
