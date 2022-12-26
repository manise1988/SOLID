using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain;
public class LeeftijdRange
{

    public int BeginAge { get; set; }

    public int EndAge { get; set; }
    public LeeftijdRange(int beginAge, int endAge)
    {
        BeginAge = beginAge;
        EndAge = endAge;
    }
    public LeeftijdRange() { }


}
