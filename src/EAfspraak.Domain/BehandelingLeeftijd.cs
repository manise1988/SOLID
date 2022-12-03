using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class BehandelingLeeftijd
    {
        private string name;
        public string Name { get { return name; } }

        private int beginAge;
        public int BeginAge { get { return beginAge; } }

        private int endAge;
        public int EndAge { get { return endAge; } }
        public BehandelingLeeftijd(string name,int beginAge,int endAge)
        {
            this.name = name;
            this.beginAge = beginAge;
            this.endAge = endAge;
        }


    }
}
