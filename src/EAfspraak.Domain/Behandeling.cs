using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Behandeling:IBehandeling
    {
        public string Name { get; set; }
        public Time DurationTime { get; set; }

        public LeeftijdRange LeeftijdRange { get; set; }
        public Behandeling(string name, Time durationTime,LeeftijdRange behandelingGroep)
        {
            Name = name;
            DurationTime = durationTime;
            LeeftijdRange = behandelingGroep;   



        }
        public Behandeling() { }

        public Behandeling(string name)
        {
            Name = name;
        }

        public bool HasAccess(Patiënt patiënt)
        {
           if(patiënt.Age>= LeeftijdRange.BeginAge && 
                patiënt.Age<=LeeftijdRange.EndAge)
                return true;
           else return false;
        }
    }
}
