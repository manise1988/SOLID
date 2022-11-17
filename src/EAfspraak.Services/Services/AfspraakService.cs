using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Infrastructure;
using DTO = EAfspraak.Infrastructure.DTO;
using EAfspraak.Services.Models;
using EAfspraak.Services.Interfaces;
using EAfspraak.Services.ViewModels;
using EAfspraak.Domain;
using EAfspraak.Domain.Verzender;


namespace EAfspraak.Services.Services;
    public class AfspraakService:IAfspraakService
    {


        AfspraakReader afspraakReader;
        public AfspraakService(string dataPath)
        {
            afspraakReader = new AfspraakReader(dataPath);


        }

    public List<Huisarts> GetHuisartsen()
    {
        return afspraakReader.GetHuisartsen();
    }

    public List<Patiënt> GetPatienten()
    {
        return afspraakReader.GetPatienten();
    }
    public List<CategoryViewModel> GetCategories()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            List<Category> domainCategory = afspraakReader.GetCategories();
            if (domainCategory != null)
                foreach (var item in domainCategory)
                {
                    List<BehandelingViewModel> behandelingen = new List<BehandelingViewModel>();
                    foreach (var itemBehandeling in item.Behandelingen)
                    {
                        behandelingen.Add(new BehandelingViewModel(itemBehandeling.Name, itemBehandeling.DurationTime.GetTime(), itemBehandeling.IsVerwijsbriefNodig));

                    }
                    categories.Add(new CategoryViewModel(item.Name, behandelingen));
                }
            return categories;
        }
    public List<KliniekViewModel> GetCentrumsMetVrijeTijden(string behandelingName)
    {
        List<KliniekViewModel> klinieks = new List<KliniekViewModel>();
            
        List<Kliniek> Centrums = afspraakReader.GetCentrums(); 
        foreach (var item in Centrums)
        {

            List<Agenda> times = item.CalculateVrijeTijd(behandelingName);
            List<KliniekAgendaViewModel> timesViewModel = new List<KliniekAgendaViewModel>();
            if (times.Count > 0)
            {
                string details = "";
                if (times.Count > 20)
                    details = item.Name + " heeft meer dan 20 behandeling plekken";
                else
                    details = item.Name + " heeft nog " + times.Count + " behandeling plekken";
                foreach (var itemAgenda in times)
                {
                    timesViewModel.Add(new KliniekAgendaViewModel(item.Name, item.Locatie,
                        itemAgenda.Specialist.FirstName + " " + itemAgenda.Specialist.LastName, itemAgenda.Specialist.BSN,
                        itemAgenda.Date, itemAgenda.Time.GetTime()));
                }
                klinieks.Add(new KliniekViewModel(item.Name, details, item.Locatie, timesViewModel));
            }
        }
        return klinieks;

    }

    public void MaakAfspraak(string categoryName, string behandelingName, string CentrumName, long patiëntBSN, long specialistBSN,
        string date, string time)
    {
        afspraakReader.MaakAfspraak(categoryName, behandelingName, CentrumName, patiëntBSN, specialistBSN, DateTime.Parse(date), new Time(time));
          


    }

}
       
