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


    public List<KliniekViewModel> GetCentrumsMetVrijeTijden(string  behandelingName, DateTime date, Werkdag werkdag)
    {

        List<Kliniek> klinieks = repotisory.ReadDataKliniek();
        klinieks.Sort();
        IBehandeling behandeling = repotisory.behandelingByNaam(behandelingName);

        List<IBerekening> berekenings = new List<IBerekening>();
        foreach (var item in klinieks)
        {
                
                berekenings.Add(new BerekeningOpDatum(item, behandeling, date));
                berekenings.Add(new BerekeningOpWerkdag(item, behandeling, werkdag));

        }
       

        if (klinieks.Count > 0)
        {
            List<KliniekViewModel> kliniekViewModelList = new List<KliniekViewModel>();

            foreach (var item in berekenings)
            {



                List<KliniekAgendaViewModel> timesViewModel = new List<KliniekAgendaViewModel>();
                if (item.BeschikbareTijdList.Count > 0)
                {
                    string details = "";
                    if (item.BeschikbareTijdList.Count > 20)
                        details = item.Kliniek.Name + " heeft meer dan 20 behandeling plekken";
                    else
                        details = item.Kliniek.Name + " heeft nog " + item.BeschikbareTijdList.Count + " behandeling plekken";
                    foreach (var itemAgenda in item.BeschikbareTijdList)
                    {
                        timesViewModel.Add(new KliniekAgendaViewModel(item.Kliniek.Name, item.Kliniek.Locatie,
                            itemAgenda.Specialist.FirstName + " " + itemAgenda.Specialist.LastName, itemAgenda.Specialist.BSN,
                            itemAgenda.Date, itemAgenda.Time.GetTime()));
                    }
                    kliniekViewModelList.Add(new KliniekViewModel(item.Kliniek.Name, details, item.Kliniek.Locatie, timesViewModel));
                }


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


    //public void MaakAfspraak(string categoryName, string behandelingName, string CentrumName, long patiëntBSN, long specialistBSN,
    //    string date, string time)
    //{
    //    afspraakReader.MaakAfspraak(categoryName, behandelingName, CentrumName, patiëntBSN, specialistBSN, DateTime.Parse(date), new Time(time));



    //}

}

