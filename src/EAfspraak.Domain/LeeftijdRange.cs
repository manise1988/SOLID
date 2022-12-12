using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class LeeftijdRange
    {

        public int BeginAge { get; }

       public int EndAge { get; }
        public LeeftijdRange(int beginAge,int endAge)
        {
            BeginAge = beginAge;
           EndAge = endAge;
        }


    }
}
