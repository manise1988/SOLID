using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class Centrum:ClassBase
    {
        public string Name { get; set; }
        public List<Specialist> Specialists { get; set; }
        public List<Behandeling> Behandelings { get; set; }

        public List<BehandelingMogelijkheid> BehandelingsMogelijkheden { get; set; }
        public Centrum(string name)
        {
            Name = name;
            Specialists = new List<Specialist>();
            Behandelings = new List<Behandeling>();
            BehandelingsMogelijkheden = new List<BehandelingMogelijkheid>();
            base.Id = Guid.NewGuid().GetHashCode();
        }

        public void AddSpesialistToCentrum(Specialist specialist)
        {
            Specialists.Add(specialist);
        }

        public void AddBehandelingToCentrum(Behandeling behandeling)
        {
            Behandelings.Add(behandeling);
        }
        public void RegisterBehandelingMogelijkheden(BehandelingMogelijkheid behandelingMogelijkheid)
        {
            BehandelingsMogelijkheden.Add(behandelingMogelijkheid);
        }
    }
}
