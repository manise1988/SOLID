using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces.MockingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Mock
{
    internal class AfspraakTest : IAfspraak
    {
        public IBehandeling Behandeling { get; }
        public DateTime Datum { get; }
        public Time BehandelingTime { get; }

        public AfspraakTest(IBehandeling behandeling, DateTime datum, Time behandelingTime)
        {
            Behandeling = behandeling;
            Datum = datum;
            BehandelingTime = behandelingTime;
        }

        public bool HasAdded()
        {
            return true;
        }
    }
}
