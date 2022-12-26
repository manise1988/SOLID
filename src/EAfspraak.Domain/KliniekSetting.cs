using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain;
public class KliniekSetting
{

    public int ZoekBereikDay { get; private set; }

    public KliniekSetting(int zoekBereikDay)
    {
        ZoekBereikDay = zoekBereikDay;
    }


}
