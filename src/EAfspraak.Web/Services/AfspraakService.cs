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
    IRepotisoryData repotisory;
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

        IBehandeling behandeling = repotisory.behandelingByNaam(behandelingName);

        List<IBerekening> berekeningList = new List<IBerekening>();

        if (date != null)
            berekeningList.Add(new BerekeningOpDatum(behandeling, (DateTime) date));
        if(werkdag!=null)
            berekeningList.Add(new BerekeningOpWerkdag(behandeling,(Werkdag) werkdag));
        else
            berekeningList.Add(new BerekeningBehandeling(behandeling));


        

        List<BeschikbareTijd> BeschikbareTijdList = afspraakManager.GetKliniekenMetVrijeTijden(berekeningList);
        


        //        List<KliniekAgendaViewModel> timesViewModel = new List<KliniekAgendaViewModel>();
        //        if (item.BeschikbareTijdList.Count > 0)
        //        {
        //            string details = "";
        //            if (item.BeschikbareTijdList.Count > 20)
        //                details = item.Kliniek.Name + " heeft meer dan 20 behandeling plekken";
        //            else
        //                details = item.Kliniek.Name + " heeft nog " + item.BeschikbareTijdList.Count + " behandeling plekken";
        //            foreach (var itemAgenda in item.BeschikbareTijdList)
        //            {
        //                timesViewModel.Add(new KliniekAgendaViewModel(item.Kliniek.Name, item.Kliniek.Locatie,
        //                    itemAgenda.Specialist.FirstName + " " + itemAgenda.Specialist.LastName, itemAgenda.Specialist.BSN,
        //                    itemAgenda.Date, itemAgenda.Time.GetTime()));
        //            }
        //            kliniekViewModelList.Add(new KliniekViewModel(item.Kliniek.Name, details, item.Kliniek.Locatie, timesViewModel));
        //        }


        //    }
        //    return kliniekViewModelList;
        //}
        // else
            return null;

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
        List<Category> domainCategory = repotisory.ReadDataCategory();
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


    //public void MaakAfspraak(string categoryName, string behandelingName, string CentrumName, long patiëntBSN, long specialistBSN,
    //    string date, string time)
    //{
    //    afspraakReader.MaakAfspraak(categoryName, behandelingName, CentrumName, patiëntBSN, specialistBSN, DateTime.Parse(date), new Time(time));



    //}

}

