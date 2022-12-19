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

    IRepotisoryData repotisory;


    public AfspraakService()
    {
        repotisory = new RepotisoryManager();
    }

    public List<Kliniek> GetKlinieken()
    {
        List<Kliniek> klinieken = repotisory.ReadDataKliniek();
        klinieken.Sort();
        return klinieken;
    }


    public List<KliniekViewModel> GetCentrumsMetVrijeTijden(IBehandeling behandeling, DateTime date, Werkdag werkdag)
    {

        List<Kliniek> klinieks = repotisory.ReadDataKliniek();
        List<IBerekening> berekenings = new List<IBerekening>();
        if (date != null && werkdag != null)
        {
            foreach (var item in klinieks)
            {
                if (date != null)
                    berekenings.Add(new BerekeningOpDatum(item, behandeling, date));
                if (werkdag != null)
                    berekenings.Add(new BerekeningOpWerkdag(item, behandeling, werkdag));

            }
        }
        else
        {
            foreach (var item in klinieks)
                berekenings.Add(new BerekeningBase(item, behandeling));

        }

        if (klinieks.Count > 0)
        {
            List<KliniekViewModel> kliniekViewModelList = new List<KliniekViewModel>();

            foreach (var item in klinieks)
            {



                List<KliniekAgendaViewModel> timesViewModel = new List<KliniekAgendaViewModel>();
                //if (times.Count > 0)
                //{
                //    string details = "";
                //    if (times.Count > 20)
                //        details = item.Name + " heeft meer dan 20 behandeling plekken";
                //    else
                //        details = item.Name + " heeft nog " + times.Count + " behandeling plekken";
                //    foreach (var itemAgenda in times)
                //    {
                //        timesViewModel.Add(new KliniekAgendaViewModel(item.Name, item.Locatie,
                //            itemAgenda.Specialist.FirstName + " " + itemAgenda.Specialist.LastName, itemAgenda.Specialist.BSN,
                //            itemAgenda.Date, itemAgenda.Time.GetTime()));
                //    }
                //    klinieks.Add(new KliniekViewModel(item.Name, details, item.Locatie, timesViewModel));
                //}


            }
            return kliniekViewModelList;
        }
         else
            return null;

    }



    public List<Patiënt> GetPatienten()
    {
        return repotisory.ReadPatiënt();
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
    //public List<KliniekViewModel> GetCentrumsMetVrijeTijden(string behandelingName)
    //{
    //    List<KliniekViewModel> klinieks = new List<KliniekViewModel>();

    //    List<Kliniek> Centrums = afspraakReader.GetKlinieken(); 
    //    foreach (var item in Centrums)
    //    {

    //        IBehandeling behandeling = new Behandeling(behandelingName);

    //        IBerekening berekening = new BerekeningBase( item, behandeling);
    //        List<BeschikbareTijd> times = berekening.Calculate();

    //        List <KliniekAgendaViewModel> timesViewModel = new List<KliniekAgendaViewModel>();
    //        if (times.Count > 0)
    //        {
    //            string details = "";
    //            if (times.Count > 20)
    //                details = item.Name + " heeft meer dan 20 behandeling plekken";
    //            else
    //                details = item.Name + " heeft nog " + times.Count + " behandeling plekken";
    //            foreach (var itemAgenda in times)
    //            {
    //                timesViewModel.Add(new KliniekAgendaViewModel(item.Name, item.Locatie,
    //                    itemAgenda.Specialist.FirstName + " " + itemAgenda.Specialist.LastName, itemAgenda.Specialist.BSN,
    //                    itemAgenda.Date, itemAgenda.Time.GetTime()));
    //            }
    //            klinieks.Add(new KliniekViewModel(item.Name, details, item.Locatie, timesViewModel));
    //        }
    //    }
    //    return klinieks;

    //}

    //public void MaakAfspraak(string categoryName, string behandelingName, string CentrumName, long patiëntBSN, long specialistBSN,
    //    string date, string time)
    //{
    //    afspraakReader.MaakAfspraak(categoryName, behandelingName, CentrumName, patiëntBSN, specialistBSN, DateTime.Parse(date), new Time(time));



    //}

}

