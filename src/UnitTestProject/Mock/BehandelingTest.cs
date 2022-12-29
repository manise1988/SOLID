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
        public string Name { get; }
        public Time DurationTime { get; }
        public LeeftijdRange LeeftijdRange { get; }

        private bool _isAccess;
        public BehandelingTest(string name,bool isAccess)
        {
            Name = name;
            this._isAccess = isAccess;
            
        }

        public bool HasAccess(Patient patient)
        {
            return _isAccess;
        }
    }
}
