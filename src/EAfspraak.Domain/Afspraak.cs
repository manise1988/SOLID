
using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain;
public class Afspraak
{
    [JsonConverter(typeof(ConcreteConverter<Behandeling>))]
    public IBehandeling Behandeling { get; }
    public DateTime Datum { get; }
    public Time BehandelingTime { get;  }
    public Specialist Specialist { get;  }
    public Patient Patient { get; }

    public Kliniek Kliniek { get; }

    public Afspraak(IBehandeling behandeling,
        DateTime datum,
        Time behandelingTime, Specialist specialist, Patient patient, Kliniek kliniek)
    {
       
        if (behandeling.HasAccess(patient))
        {
           Behandeling = behandeling;
            Datum = datum;
            BehandelingTime = behandelingTime;
            Specialist = specialist;
            Patient = patient;
            Kliniek = kliniek;
        }
        else
        {
            Behandeling = null;
            BehandelingTime = null;
            Specialist = null;
            Patient = null;
            Kliniek = null;
        }



    }

    public bool IsAfspraakInBehandeling()
    {
        DateTime currentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        if (Datum >= DateTime.Now)
            return false;
        else
            return true;
    }


}