using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Interfaces
{
    public interface IBerekening
    {
        public IBehandeling Behandeling { get; }
        public List<BeschikbareTijd> Calculate (Kliniek kliniek);
    }
}
