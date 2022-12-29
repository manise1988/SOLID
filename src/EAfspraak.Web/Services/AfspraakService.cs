using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Web.ViewModels;
using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;
using EAfspraak.Infrastructure;
using EAfspraak.Domain.Manager;

namespace EAfspraak.Web.Services;
public class AfspraakService
    {

    private readonly IRepositoryAfspraak repository;
    private readonly IAfspraakManager afspraakManager;

    private BerekeningManager berekeningManager;

    public AfspraakService()
    {
        repository = new RepositoryManager();
        afspraakManager = new AfspraakManager(repository);
    }



    public List<KliniekViewModel> GetKliniekenMetVrijeTijden(string behandelingName, object date, object werkdag)
    {

        IBehandeling behandeling = afspraakManager.GetBehandelingByNaam(behandelingName);

        List<IBerekening> berekeningList = new List<IBerekening>();

        if (date != null)
            berekeningList.Add(new BerekeningOpDatum(behandeling, (DateTime) date));
        if(werkdag!=null)
            berekeningList.Add(new BerekeningOpWerkdag(behandeling,(Werkdag) werkdag));
        else
            berekeningList.Add(new BerekeningBehandeling(behandeling));

        berekeningManager = new BerekeningManager(repository,berekeningList);
        List<BeschikbareTijd> BeschikbareTijdList = berekeningManager.GetKliniekenMetVrijeTijden();


        List<KliniekViewModel> kliniekViewModelList = new List<KliniekViewModel>();
         
        if (BeschikbareTijdList.Count > 0)
        {
            BeschikbareTijdList.Sort();
            foreach (var item in BeschikbareTijdList.GroupBy(x => x.Kliniek).ToArray())
            {


                string details = "";
                if (item.Count() > 20)
                    details = item.First().Kliniek.Name + " heeft meer dan 20 plekken";
                else
                    details = item.First().Kliniek.Name + " heeft nog " + item.Count().ToString() + " plekken";
                List<KliniekAgendaViewModel> timesViewModel = new List<KliniekAgendaViewModel>();
                foreach (var itemAgenda in item)
                {
                    timesViewModel.Add(new KliniekAgendaViewModel(item.First().Kliniek.Name, item.First().Kliniek.Locatie,
                        itemAgenda.Specialist.BSN,
                        itemAgenda.Date, itemAgenda.Time.GetTime()));
                }
                kliniekViewModelList.Add(new KliniekViewModel(item.First().Kliniek.Name, details, item.First().Kliniek.Locatie, timesViewModel));
            }
        }


   

        return kliniekViewModelList;

    }

    public List<Patient> GetPatienten()
    {
        return afspraakManager.GetPatienten();
       
    }

    public List<Afspraak> GetAfsprakenByPatient(Patient patient)
    {
        List <Afspraak> afspraakList=afspraakManager.GetAfsprakenByPatient(patient);
       return afspraakList;
       
    }
    public List<CategoryViewModel> GetCategories()
    {
        List<CategoryViewModel> categories = new List<CategoryViewModel>();
        List<Category> domainCategory = afspraakManager.GetCategories();
        if (domainCategory != null)
            foreach (var item in domainCategory)
            {
                List<BehandelingViewModel> behandelingen = new List<BehandelingViewModel>();
                foreach (var itemBehandeling in item.Behandelingen)
                {
                    behandelingen.Add(new BehandelingViewModel(itemBehandeling.Name, itemBehandeling.DurationTime.GetTime()));

                }
                categories.Add(new CategoryViewModel(item.Name, behandelingen));
            }
        return categories;

    }


    public void MaakAfspraak(string behandelingName, string kliniekName,
        long patientBSN, long specialistBSN,
        string date, string time)
    {
        
        IBehandeling behandeling =afspraakManager.GetBehandelingByNaam(behandelingName);
        Patient patient = afspraakManager.GetPatientByBSN(patientBSN);
        Kliniek kliniek = afspraakManager.GetKliniekByNaam(kliniekName);
        Specialist specialist = kliniek.Specialisten.Where(x => x.BSN == specialistBSN).First();

        afspraakManager.MaakAfspraak( behandeling, kliniek, patient,
            specialist, DateTime.Parse(date), new Time(time));



    }

}

