using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Domain.Interfaces.MockingInterfaces;

namespace EAfspraak.Domain.Interfaces;
public interface IAfspraakManager
{
    public List<Afspraak> GetAfsprakenByPatient(Patient patient);
    public void MaakAfspraak(IBehandeling behandeling, Kliniek kliniek, Patient patient, Specialist specialist, DateTime datum, Time time);
    public List<Kliniek> GetKlinieken();

    public Kliniek GetKliniekByNaam(string kliniekNaam);
    public List<Patient> GetPatienten();

    public Patient GetPatientByBSN(long patientBSN);

    public List<Category> GetCategories();
    public IBehandeling GetBehandelingByNaam(string behandelingNaam);

}