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
        public List<Specialist> Specialists { get;  }
        private  List<Behandeling> Behandelings { get; set; }

        private List<BehandelingMogelijkheid> BehandelingsMogelijkheden { get; set; }
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
        public void AddSpesialistToCentrum(List<Specialist> specialisten)
        {
            Specialists.AddRange(specialisten);
        }
        public void AddBehandelingToCentrum(Behandeling behandeling)
        {
            Behandelings.Add(behandeling);
        }
        public void RegisterBehandelingMogelijkheden(BehandelingMogelijkheid behandelingMogelijkheid)
        {
            BehandelingsMogelijkheden.Add(behandelingMogelijkheid);
        }

        public List<BehandelingMogelijkheid> GetBehandelingMogelijkheids() {
            return BehandelingsMogelijkheden;
        }

        public List<Behandeling> GetBehandelings()
        {
            return Behandelings;
        }

        public bool HaveToBehandeling(string behandelingNmae)
        {
            if (Behandelings.Where(x => x.Name == behandelingNmae).Any())
                return true;
            else
                return false;
        }
    }
}
