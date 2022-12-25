using EAfspraak.Domain.Interfaces;
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
    public List<Afspraak> GetAfsprakenByPatient(Patiënt patiënt)
    {
        List<Afspraak> data = new List<Afspraak>();

        return data;
    }
    public void MaakAfspraak(IBehandeling behandeling, Kliniek kliniek, Patiënt patiënt, Specialist specialist, DateTime datum, Time time)
    {
        Kliniek kliniekData = new Kliniek(kliniek.Name, kliniek.Locatie);
        Afspraak afspraak = new Afspraak(behandeling, datum, time, specialist, patiënt, kliniekData);
        repotisory.SaveAfspraak(afspraak);

    }
    public List<Kliniek> GetKlinieken()
    {
        List<Kliniek> klinieken = repotisory.ReadKliniek();
        klinieken.Sort();
        return klinieken;
    }
    public List<Patiënt> GetPatienten()
    {
        return repotisory.ReadPatiënt();

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

    public Patiënt GetPatiëntByBSN(long patiëntBSN)
    {
        return repotisory.ReadPatiëntByBSN(patiëntBSN);
    }
}
