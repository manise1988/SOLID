using EAfspraak.Domain.Interfaces;
using EAfspraak.Domain.Interfaces.MockingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Domain.Manager;
public class AfspraakManager:IAfspraakManager
{


    private readonly IRepositoryAfspraak repotisory;
    public AfspraakManager(IRepositoryAfspraak repotisoryData)
    {

        repotisory = repotisoryData;
    }
    public List<Afspraak> GetAfsprakenByPatient(Patient patient)
    {
        List<Afspraak> data = new List<Afspraak>();
        data = repotisory.ReadAfspraakByPatient(patient.BSN);
        if(data!=null)
            if(data.Count>0)
                if (data.Where(x => x.Datum.Date >= DateTime.Now.Date).Any())
                    return data.Where(x=> x.Datum.Date>= DateTime.Now.Date).ToList();
        return default;
    }

    public bool AddPatient(Patient patient)
    {
       
       return repotisory.SavePatient(patient);

    }

    public bool MaakAfspraak(IBehandeling behandeling, Kliniek kliniek, Patient patient, Specialist specialist, DateTime datum, Time time)
    {
        Kliniek kliniekData = new Kliniek(kliniek.Name, kliniek.Locatie);
       List<Afspraak> afspraakList = repotisory.ReadAfspraakByKliniekNaam(kliniek.Name, datum).ToList();
        afspraakList.AddRange(repotisory.ReadAfspraakByPatient(patient.BSN,datum).ToList());
        
           
            Afspraak afspraak = new Afspraak(behandeling, datum, time, specialist, patient, kliniekData,afspraakList.ToArray());
            if (afspraak.Patient != null)
            {
                repotisory.SaveAfspraak(afspraak);
                return true;
            }
        
        return false;
    }
    public List<Kliniek> GetKlinieken()
    {
        List<Kliniek> klinieken = repotisory.ReadKliniek();
        klinieken.Sort();
        return klinieken;
    }
    public List<Patient> GetPatienten()
    {
        return repotisory.ReadPatient();

    }
    public List<Category> GetCategories()
    {
       return  repotisory.ReadCategory();
    }

    

    public IBehandeling GetBehandelingByNaam(string behandelingNaam)
    {
        return repotisory.ReadBehandelingByNaam(behandelingNaam);
    }

    public Kliniek GetKliniekByNaam(string kliniekNaam)
    {
       return repotisory.ReadKliniekByNaam(kliniekNaam);
    }

    public Patient GetPatientByBSN(long patientBSN)
    {
        return repotisory.ReadPatientByBSN(patientBSN);
    }
}
