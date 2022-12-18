
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Abstracts;
using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;


namespace EAfspraak.Domain
{
    public class Kliniek:IComparable<Kliniek>
    {

        public string Name { get; }
        public string Locatie { get; }
        public KliniekSetting KliniekSetting { get; }
        public List<Specialist> Specialisten { get; private set; }
        public List<IBehandeling> Behandelingen { get; private set; }
        public List<BehandelingAgenda> BehandelingAgendas { get; private set; }
        public List<Afspraak> Afspraken { get; private set; }
        public  List<GeslotenDagen> GeslotenDagen { get; private set; }

         
       public Kliniek(string name, string locatie , KliniekSetting kliniekSetting)
       {
            Name = name;
            Locatie = locatie;
            KliniekSetting = kliniekSetting;

            Specialisten = new List<Specialist>();
            Behandelingen = new List<IBehandeling>();
            BehandelingAgendas = new List<BehandelingAgenda>();
            Afspraken = new List<Afspraak>();
            GeslotenDagen = new List<GeslotenDagen>();

        }
        public Kliniek(string name, string locatie)
        {
            Name = name;
            Locatie = locatie;
            KliniekSetting kliniekSetting = new KliniekSetting(30);
            KliniekSetting = kliniekSetting;

            Specialisten = new List<Specialist>();
            Behandelingen = new List<IBehandeling>();
            BehandelingAgendas = new List<BehandelingAgenda>();
            Afspraken = new List<Afspraak>();
            GeslotenDagen = new List<GeslotenDagen>();

        }

        public void AddVakantieDagenToKliniek(GeslotenDagen vakantie)
        {
            GeslotenDagen.Add(vakantie);
        }
        public void AddAfspraakToKliniek(Afspraak afspraak)
        {
            if (!afspraak.Behandeling.HasAccess(afspraak.Patiënt))
            
                Afspraken.Add(afspraak);
        }
        public void AddSpesialistToKliniek(Specialist specialist)
        {
            Specialisten.Add(specialist);
        }
        public void AddSpesialistToKliniek(List<Specialist> specialisten)
        {
            Specialisten.AddRange(specialisten);
        }
        public void AddBehandelingToKliniek(IBehandeling behandeling)
        {
            Behandelingen.Add(behandeling);
        }
        public void RegisterBehandelingAgenda(BehandelingAgenda behandelingAgenda)
        {
            BehandelingAgendas.Add(behandelingAgenda);
        }

        public int CompareTo(Kliniek? obj)
        {
            return String.Compare(this.Locatie, obj.Locatie);
        }
    }
}
