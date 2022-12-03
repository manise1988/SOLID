using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class LeeftijdRange
    {

        private int beginAge;
        public int BeginAge { get { return beginAge; } }

        private int endAge;
        public int EndAge { get { return endAge; } }
        public LeeftijdRange(int beginAge,int endAge)
        {
            this.beginAge = beginAge;
            this.endAge = endAge;
        }


    }
}
