using EAfspraak.Domain.Interfaces.MockingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain;
public class Behandeling : IBehandeling
{
    public string Name { get; set; }
    public Time DurationTime { get; set; }

    public LeeftijdRange LeeftijdRange { get; set; }
    public Behandeling(string name, Time durationTime, LeeftijdRange leeftijdRange)
    {
        Name = name;
        DurationTime = durationTime;
        LeeftijdRange = leeftijdRange;



    }
    //public Behandeling() { }

    //public Behandeling(string name)
    //{
    //    Name = name;
    //}

    public bool HasAccess(Patient patient)
    {
        if (patient.Age >= LeeftijdRange.BeginAge &&
             patient.Age <= LeeftijdRange.EndAge)
            return true;
        else return false;
    }
}
