using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Mock
{
    public class BehandelingTest : IBehandeling
    {
        public string Name { get; private set; }

        public Time DurationTime { get; private set; }

        public bool IsVerwijsbriefNodig { get; private set; }

        public LeeftijdRange LeeftijdRange { get; private set; }

        private bool isAccess;
        public BehandelingTest(string name,bool isAccess)
        {
            Name = name;
            isAccess = true;
        }

        public bool HasAccess(Patiënt patiënt)
        {
            return isAccess;
        }
    }
}
