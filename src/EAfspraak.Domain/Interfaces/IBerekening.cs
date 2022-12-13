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
        public Kliniek Kliniek { get; }
        public List<BeschikbareTijd> Calculate();

    }
}
