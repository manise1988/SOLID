using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class BerekeningZoekParameter
    {
        public string ZoekparameterValue { get; }
        public ZoekParameterType ZoekParameterName { get; }

       public BerekeningZoekParameter(string zoekparameterValue, ZoekParameterType zoekParameterName)        {
            ZoekparameterValue = zoekparameterValue;
            ZoekParameterName = zoekParameterName;
        }

    }
}
