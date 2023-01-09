
using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces.MockingInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain;
public class Afspraak:IAfspraak
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
        Behandeling = behandeling;
        Patient = patient;
        
        if (HasAdded())
        {
            Datum = datum;
            BehandelingTime = behandelingTime;
            Specialist = specialist;
            Kliniek = kliniek;
        }
        else
        {
            Behandeling = null;
            Patient = null;
        }
       
    }

    public bool HasAdded()
    {
        if (Patient != null)
            return Behandeling.HasAccess(Patient);
        else
            return false;
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