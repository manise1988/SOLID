using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EAfspraak.Domain.Interfaces
{
    public interface IBehandeling
    {
        
        public string Name { get; }
        public Time DurationTime { get; }
        public bool IsVerwijsbriefNodig { get; }
        public BehandelingGroep BehandelingGroep { get; }
        public bool HasAccess(Patiënt patiënt);
    }
}
