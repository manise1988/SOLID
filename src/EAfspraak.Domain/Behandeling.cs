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
        private string name;
        private Time durationTime;
        public string Name { get { return name; } }
        public Time DurationTime { get { return durationTime; } }

        private bool isVerwijsbriefNodig;
        public bool IsVerwijsbriefNodig { get { return isVerwijsbriefNodig; } }

        private BehandelingLeeftijd behandelingGroep;
        public BehandelingLeeftijd BehandelingGroep { get { return behandelingGroep; } }
        public Behandeling(string name, Time durationTime, bool isVerwijsbriefNodig,BehandelingLeeftijd behandelingGroep)
        {
            this.name = name;
            this.durationTime = durationTime;
            this.isVerwijsbriefNodig = isVerwijsbriefNodig;
            this.behandelingGroep = behandelingGroep;   



        }

        public bool HasAccess(Patiënt patiënt)
        {
           if(patiënt.Age>= behandelingGroep.BeginAge && 
                patiënt.Age<=behandelingGroep.EndAge)
                return true;
           else return false;
        }
    }
}
