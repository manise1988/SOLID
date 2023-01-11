
using EAfspraak.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain;
public class BeschikbareTijd : IComparable<BeschikbareTijd>
{
    public Time Time { get; set; }

    public string Date { get; set; }

    public Specialist Specialist { get; set; }

    public Kliniek Kliniek { get; set; }
    public BeschikbareTijd(Time time, DateTime date, Specialist specialist, Kliniek kliniek)
    {
        Time = time;
        Date = date.ToShortDateString();
        Specialist = specialist;
        Kliniek = kliniek;
    }

    public int CompareTo(BeschikbareTijd? other)
    {
        TimeBerekening timeBerekening = new TimeBerekening();
        if (timeBerekening.IsTime1Smaller(this.Time, other.Time))
            return -1;
        else if (this.Time == other.Time)
            return 0;
        else
            return 1;
    }
}