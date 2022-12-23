
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Abstracts;
using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using Newtonsoft.Json;

namespace EAfspraak.Domain
{
    public class Kliniek : IComparable<Kliniek>
    {

        public string Name { get; set; }
        public string Locatie { get; set; }
        public KliniekSetting KliniekSetting { get; set; }
        public Specialist[] Specialisten { get; set; }

        [JsonConverter(typeof(ConcreteConverter<Behandeling[]>))]
        public IBehandeling[] Behandelingen { get; set; }
        public BehandelingAgenda[] BehandelingAgendas { get; set; }
        public Afspraak[] Afspraken { get; set; }
        public GeslotenDagen[] GeslotenDagen { get; set; }

        public Kliniek()
        { }
        //public Kliniek(string name, string locatie, KliniekSetting kliniekSetting,List<Behandeling> behandelingen, List<GeslotenDagen> geslotenDagen)
        //{
        //    Name = name;
        //    Locatie = locatie;
        //    KliniekSetting = kliniekSetting;

        //    //Specialisten = new List<Specialist>();

        //    Behandelingen = new List<IBehandeling>();
        //    Behandelingen.AddRange(behandelingen);

        //    BehandelingAgendas = new List<BehandelingAgenda>();

        //    Afspraken = new List<Afspraak>();

        //    GeslotenDagen = geslotenDagen;

        //}
        public Kliniek(string name, string locatie , KliniekSetting kliniekSetting)
       {
            Name = name;
            Locatie = locatie;
            KliniekSetting = kliniekSetting;

          
        }
        public Kliniek(string name, string locatie)
        {
            Name = name;
            Locatie = locatie;
            KliniekSetting kliniekSetting = new KliniekSetting(30);
            KliniekSetting = kliniekSetting;

          
        }

        public void AddVakantieDagenToKliniek(GeslotenDagen vakantie)
        {
            GeslotenDagen.Append(vakantie);
        }
        public void AddAfspraakToKliniek(Afspraak afspraak)
        {
            if (!afspraak.Behandeling.HasAccess(afspraak.Patiënt))

                Afspraken.Append(afspraak);
        }
        public void AddSpesialistToKliniek(Specialist specialist)
        {
            Specialisten.Append(specialist);
        }
        public void AddBehandelingToKliniek(IBehandeling behandeling)
        {
            Behandelingen.Append(behandeling);
        }
        public void AddBehandelingAgenda(BehandelingAgenda behandelingAgenda)
        {
            BehandelingAgendas.Append(behandelingAgenda);
        }

        public int CompareTo(Kliniek? obj)
        {
            return String.Compare(this.Locatie, obj.Locatie);
        }
    }
}
