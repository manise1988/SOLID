
using EAfspraak.Domain;
namespace EAfspraak.Infrastructure.Data;


public class Category
{
    public string Name { get; set; }
    public List<Behandeling> Behandelingen { get; set; }
}

public class Kliniek
{
    public string Name { get; set; }
    public string Locatie { get; set; }
    public EAfspraak.Domain.KliniekSetting KliniekSetting { get; set; }
    public Specialist[] Specialisten { get; set; }
    public List<EAfspraak.Domain.Behandeling> Behandelingen { get; set; }
    public BehandelingAgenda[] BehandelingAgendas { get; set; }
    public object Afspraken { get; set; }
    public List<EAfspraak.Domain.GeslotenDagen> GeslotenDagen { get; set; }
}


public class Specialist
{
    public long BSN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EAfspraak.Infrastructure.Data.Category Category { get; set; }
}




public class BehandelingAgenda
{
    public Specialist Specialist { get; set; }
    public string Werkdag { get; set; }
    public string BeginTime { get; set; }
    public string EndTime { get; set; }
}


public class Afspraak
{
    public string CategoryName { get; set; }
    public string BehandelingName { get; set; }
    public string BehandelingDatum { get; set; }
    public string BeginTime { get; set; }
    public string AfspraakStatus { get; set; }
    public long PatientBSN { get; set; }

    public long SpecialistBSN { get; set; }

    public string KliniekName { get; set; }

    public Afspraak(string categoryName, string behandelingName,
                  string afspraakStatus, string behandelingDatum,
                  string beginTime, long patientBSN, long specialistBSN, string kliniekName)
    {
        PatientBSN = patientBSN;
        CategoryName = categoryName;
        BehandelingName = behandelingName;
        AfspraakStatus = afspraakStatus;
        BehandelingDatum = behandelingDatum;
        BeginTime = beginTime;
        SpecialistBSN = specialistBSN;
        KliniekName = kliniekName;

    }


}


