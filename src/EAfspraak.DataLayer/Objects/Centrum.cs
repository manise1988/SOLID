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
        private List<BehandelingAgenda> BehandelingAgendas { get; set; }

        private List<BehandelingMogelijkHeid> BehandelingMogelijkHeden { get; set; }
        private List<Patiënt> patiënts { get; set; }
        public Centrum(string name)
        {
            Name = name;
            Specialists = new List<Specialist>();
            Behandelings = new List<Behandeling>();
            BehandelingAgendas = new List<BehandelingAgenda>();
            
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
        public void RegisterBehandelingAgenda(BehandelingAgenda behandelingAgenda)
        {
            BehandelingAgendas.Add(behandelingAgenda);
        }

        public List<BehandelingAgenda> GetBehandelingMogelijkheids() {
            return BehandelingAgendas;
        }

        public List<Behandeling> GetBehandelings()
        {
            return Behandelings;
        }

        public bool HaveToBehandeling(string behandelingName)
        {
            if (Behandelings.Where(x => x.Name == behandelingName).Any())
                return true;
            else
                return false;
        }


        public List<BehandelingMogelijkHeid> CalculateWachtLijst(long spesialistBSN, string behandelingName)
        {
            BehandelingMogelijkHeden = new List<BehandelingMogelijkHeid>();

            Behandeling behandeling = Behandelings.Where(x => x.Name == behandelingName).First();
            if (behandeling!= null)
            {
                Specialist specialist = Specialists.Where(x => x.BSN == spesialistBSN &&
                x.Category.Behandelingen.Where(y => y.Name == behandelingName).Any()
                ).First();
                
                //GetBehandelingMogelijkheids

            }
            
            return BehandelingMogelijkHeden;
        }
    }
}
