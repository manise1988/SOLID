using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EAfspraak.Domain.Interfaces.MockingInterfaces;
public interface IBehandeling
{

    public string Name { get; }
    public Time DurationTime { get; }
    public LeeftijdRange LeeftijdRange { get; }
    public bool HasAccess(Patient patient);
}