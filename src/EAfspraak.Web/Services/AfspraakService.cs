using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Web.ViewModels;
using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;
using EAfspraak.Infrastructure;

namespace EAfspraak.Web.Services;
    public class AfspraakService
    {


    AfspraakManager afspraakManager;
    IRepotisoryAfspraak repotisory;
    public AfspraakService()
    {
        repotisory = new RepotisoryManager();
        afspraakManager = new AfspraakManager(repotisory);
    }

    public List<Kliniek> GetKlinieken()
    {
       return afspraakManager.GetKlinieken();
    }


    public List<KliniekViewModel> GetKliniekenMetVrijeTijden(string behandelingName, object date, object werkdag)
    {

        IBehandeling behandeling = repotisory.ReadBehandelingByNaam(behandelingName);

        List<IBerekening> berekeningList = new List<IBerekening>();

        if (date != null)
            berekeningList.Add(new BerekeningOpDatum(behandeling, (DateTime) date));
        if(werkdag!=null)
            berekeningList.Add(new BerekeningOpWerkdag(behandeling,(Werkdag) werkdag));
        else
            berekeningList.Add(new BerekeningBehandeling(behandeling));


        

        List<BeschikbareTijd> BeschikbareTijdList = afspraakManager.GetKliniekenMetVrijeTijden(berekeningList);


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

    public List<Patiënt> GetPatienten()
    {
        return repotisory.ReadPatiënt();
       
    }

    public List<Afspraak> GetAfsprakenList(Patiënt patiënt)
    {
        //List <Afspraak> afspraakList= new List<Afspraak>();
        //List<Kliniek> kliniekList = repotisory.ReadDataKliniek();
        //foreach (var itemKliniek in kliniekList)
        //{
        //    foreach (var itemAfspraak in itemKliniek.Afspraken)
        //    {
        //        if(itemAfspraak.Patiënt.BSN==patiënt.BSN)
        //        {
        //            afspraakList.Add(itemAfspraak);
        //        }
        //    }
        //}
        //return afspraakList;
        return null;
    }
    public List<CategoryViewModel> GetCategories()
    {
        List<CategoryViewModel> categories = new List<CategoryViewModel>();
        List<Category> domainCategory = repotisory.ReadCategory();
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
        long patiëntBSN, long specialistBSN,
        string date, string time)
    {
        
        IBehandeling behandeling = repotisory.ReadBehandelingByNaam(behandelingName);
        Patiënt patiënt = repotisory.ReadPatiëntByBSN(patiëntBSN);
        Kliniek kliniek = repotisory.ReadKliniekByNaam(kliniekName);
        Specialist specialist = kliniek.Specialisten.Where(x => x.BSN == specialistBSN).First();

        afspraakManager.MaakAfspraak( behandeling, kliniek, patiënt,
            specialist, DateTime.Parse(date), new Time(time));



    }

}

