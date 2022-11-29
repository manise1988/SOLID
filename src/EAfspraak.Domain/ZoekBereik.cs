using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class ZoekBereik
    {

        private int day;
        public int Day { get { return day; } }

       public ZoekBereik( int day)
        {
            this.day = day;
        }

    
    }
}
