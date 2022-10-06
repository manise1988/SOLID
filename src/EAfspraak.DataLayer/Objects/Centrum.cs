using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.DataLayer.Objects
{
    public class Centrum
    {
        public string Name { get; set; }
        public List<Specialist> Specialists { get;  }
        private  List<Behandeling> Behandelings { get; set; }
        private List<BehandelingCalender> BehandelingCalenders { get; set; }

        private List<BehandelingMogelijkHeid> BehandelingMogelijkHeden { get; set; }
        private List<Patiënt> patiënts { get; set; }
        public Centrum(string name)
        {
            Name = name;
            Specialists = new List<Specialist>();
            Behandelings = new List<Behandeling>();
            BehandelingCalenders = new List<BehandelingCalender>();
            
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
        public void RegisterBehandelingCalenders(BehandelingCalender behandelingCalenders)
        {
            BehandelingCalenders.Add(behandelingCalenders);
        }

        public List<BehandelingCalender> GetBehandelingMogelijkheids() {
            return BehandelingCalenders;
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
        public List<BehandelingMogelijkHeid> CalculateWachtLijst(long spesialistBSN, string behandelingName)
        {
            BehandelingMogelijkHeden = new List<BehandelingMogelijkHeid>();

            
            return BehandelingMogelijkHeden;
        }
    }
}
