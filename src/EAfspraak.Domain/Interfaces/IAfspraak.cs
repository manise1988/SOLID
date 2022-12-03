using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Interfaces
{
    public interface IAfspraak
    {
        public DateTime RegisterDate { get; }

        public Category Category { get; }

        public IBehandeling Behandeling { get; }

        public AfspraakStatus AfspraakStatus { get; }
        public DateTime Datum { get; }

        public Time BeginTime { get; }

        public string Details { get; }


        public Specialist Specialist { get; }
        public Patiënt Patiënt { get; }


        public bool IsAfspraakInBehandeling();
    }
}
