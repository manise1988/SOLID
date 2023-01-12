
using EAfspraak.Domain.Common;
using EAfspraak.Domain.Interfaces;
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
    public IBehandeling Behandeling { get;  }
    public DateTime Datum { get;  }
    public Time BehandelingTime { get;  }
    public Specialist Specialist { get;  }
    public Patient Patient { get;  }
    public Kliniek Kliniek { get;  }

    TimeBerekening timeBerekening = new TimeBerekening();
    public Afspraak(IBehandeling behandeling,
        DateTime datum,
        Time behandelingTime, Specialist specialist, Patient patient, Kliniek kliniek,
        IAfspraak[] afspraakList)
    {
        Behandeling = behandeling;
        Patient = patient;
        BehandelingTime = behandelingTime;
        Specialist = specialist;
        Kliniek = kliniek;

        if (HasAdded( afspraakList))
        {
            Datum = datum;
        }
        else
        {
            Behandeling = null;
            Patient = null;
            Specialist = null;
            Kliniek = null;
            BehandelingTime = null;
        }
       
    }

    public bool HasAdded(IAfspraak[] afspraakList)
    {
        bool isAdded = false;

        if (Patient != null)
            isAdded= Behandeling.HasAccess(Patient);

        if (isAdded)
        {
            if(afspraakList != null)
                if (afspraakList.Count() > 0)
                {
                    if(afspraakList.Where(x=> x.Patient.BSN == this.Patient.BSN &&
                    timeBerekening.IsTime1Equallarger(this.BehandelingTime, x.BehandelingTime) &&
                    timeBerekening.IsTime1Smaller(this.BehandelingTime,timeBerekening.VolgendeTime(x.BehandelingTime,x.Behandeling.DurationTime)) ).Any())
                        isAdded = false;

                    if(afspraakList.Where(x => x.Specialist.BSN == this.Specialist.BSN &&
                        x.Kliniek.Name== this.Kliniek.Name &&
                        timeBerekening.IsTime1Equallarger(this.BehandelingTime, x.BehandelingTime) &&
                        timeBerekening.IsTime1Smaller(this.BehandelingTime, timeBerekening.VolgendeTime(x.BehandelingTime, x.Behandeling.DurationTime))).Any())
                        isAdded= false;
                }
        }
       
        return isAdded;
        
    }

    //public bool IsAfspraakInBehandeling()
    //{
    //    DateTime currentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
    //    if (Datum >= DateTime.Now)
    //        return false;
    //    else
    //        return true;
    //}


}