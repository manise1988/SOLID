﻿using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain
{
    public class Behandeling:IBehandeling
    {
        public string Name { get; }
        public Time DurationTime { get; }

        public bool IsVerwijsbriefNodig { get; }

        public LeeftijdRange BehandelingGroep { get; }
        public Behandeling(string name, Time durationTime, bool isVerwijsbriefNodig,LeeftijdRange behandelingGroep)
        {
            Name = name;
            DurationTime = durationTime;
            IsVerwijsbriefNodig = isVerwijsbriefNodig;
            BehandelingGroep = behandelingGroep;   



        }

        public Behandeling(string name)
        {
            Name = name;
        }

        public bool HasAccess(Patiënt patiënt)
        {
           if(patiënt.Age>= BehandelingGroep.BeginAge && 
                patiënt.Age<=BehandelingGroep.EndAge)
                return true;
           else return false;
        }
    }
}
