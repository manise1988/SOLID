using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EAfspraak.Domain.Interfaces.MockingInterfaces;

namespace EAfspraak.Domain.Interfaces;
public interface IRepositoryAfspraak
{
    public List<Kliniek> ReadKliniek();
    public Afspraak[] ReadAfspraakByKliniekNaam(string kliniekNaam);
    public Afspraak[] ReadAfspraakByKliniekNaam(string kliniekNaam, DateTime date);
   // public bool IsAfspraakMogelijk(string kliniekNaam, long specialistBSN, long patientBSN, DateTime date, Time time);
    public Kliniek ReadKliniekByNaam(string kliniekNaam);
    public void SaveAfspraak(Afspraak afspraak);
    public List<Afspraak> ReadAfspraakByPatient(long patientBSN);

    public List<Afspraak> ReadAfspraakByPatient(long patientBSN, DateTime date);
    public List<Category> ReadCategory();
    public Category ReadCategoryByNaam(string categoryNaam);
    public IBehandeling ReadBehandelingByNaam(string behandelingNaam);
    public List<Patient> ReadPatient();
    public Patient ReadPatientByBSN(long bsn);

    public bool SavePatient(Patient patient);

}

 

