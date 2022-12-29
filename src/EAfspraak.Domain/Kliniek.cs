
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

namespace EAfspraak.Domain;
public class Kliniek : IComparable<Kliniek>
{

    public string Name { get; set; }
    public string Locatie { get; set; }
    public KliniekSetting KliniekSetting { get; set; }
    public Specialist[] Specialisten { get; set; }

    [JsonConverter(typeof(ConcreteConverter<Behandeling[]>))]
    public IBehandeling[] Behandelingen { get; set; }
    public BehandelingAgenda[] BehandelingAgendas { get; set; }
    //  public Afspraak[] Afspraken { get; set; }
    public GeslotenDagen[] GeslotenDagen { get; set; }

    public Kliniek()
    { }
    public Kliniek(string name, string locatie, KliniekSetting kliniekSetting)
    {
        Name = name;
        Locatie = locatie;
        KliniekSetting = kliniekSetting;


    }
    public Kliniek(string name, string locatie)
    {
        Name = name;
        Locatie = locatie;
        KliniekSetting kliniekSetting = new KliniekSetting(7);
        KliniekSetting = kliniekSetting;


    }

    public void AddVakantieDagenToKliniek(GeslotenDagen vakantie)
    {
        List<GeslotenDagen> list = new List<GeslotenDagen>();
        if (GeslotenDagen != null)
            list = GeslotenDagen.ToList();
        list.Add(vakantie);
        GeslotenDagen = list.ToArray();

       
    }
    public void AddSpesialistToKliniek(Specialist specialist)
    {


        List<Specialist> list = new List<Specialist>();
        if (Specialisten != null)
            list = Specialisten.ToList();
        list.Add(specialist);
        Specialisten = list.ToArray();

    }
    public void AddBehandelingToKliniek(IBehandeling behandeling)
    {
        List<IBehandeling> list = new List<IBehandeling>();
        if (Behandelingen != null)
            list = Behandelingen.ToList();
        list.Add(behandeling);
        Behandelingen = list.ToArray();

       
    }
    public void AddBehandelingAgenda(BehandelingAgenda behandelingAgenda)
    {
        List<BehandelingAgenda> list = new List<BehandelingAgenda>();
        if (BehandelingAgendas != null)
            list = BehandelingAgendas.ToList();
        list.Add(behandelingAgenda);
        BehandelingAgendas = list.ToArray();
        
    }

    public int CompareTo(Kliniek? obj)
    {
        return String.Compare(this.Locatie, obj.Locatie);
    }
}
