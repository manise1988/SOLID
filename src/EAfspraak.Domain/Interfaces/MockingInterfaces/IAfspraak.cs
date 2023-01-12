using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Interfaces.MockingInterfaces;
public interface IAfspraak
{
    public IBehandeling Behandeling { get; }
    public DateTime Datum { get; }
    public Time BehandelingTime { get; }

    public Patient Patient { get; }

    public Specialist Specialist { get; }
    public Kliniek Kliniek { get; }
    public bool HasAdded(IAfspraak[] afspraakList);
}
