
using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;
using Newtonsoft.Json;
using System;

namespace EAfspraak.Infrastructure.Data;
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


