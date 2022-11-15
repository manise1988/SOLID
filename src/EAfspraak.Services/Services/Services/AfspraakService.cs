using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Infrastructure;
using DTO = EAfspraak.Infrastructure.DTO;
using EAfspraak.Services.DataModel;
using EAfspraak.Services.Services.Interfases;
using EAfspraak.Services.ViewModels;
using EAfspraak.Domain;

namespace EAfspraak.Services.Services.Services
{
    public class AfspraakService : IAfspraakService
    {
        private List<Category> Categories { get; set; }
        private List<Huisarts> Huisartsen { get; set; }

        DomainDataModel dataLayer;
        public AfspraakService(string dataPath)
        {
            dataLayer = new DomainDataModel(dataPath);

            Categories = dataLayer.GetCategory();
            //Patiënten = dataLayer.GetPatiënten(Categories);
            //Centrums = dataLayer.GetCentrums(Categories,Patiënten);

            Huisartsen = dataLayer.GetHuisarts();



        }

        public List<CategoryViewModel> GetCategories()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            if(Categories != null)
                foreach (var item in Categories)
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
        public List<Huisarts> GetHuisartsen()
        {
            return Huisartsen;
        }

        public List<Patiënt> GetPatienten()
        {
            return dataLayer.GetPatiënten(Categories);
        }
        public void MaakAfspraak(string categoryName, string behandelingName, string CentrumName, long patiëntBSN, long specialistBSN,
            string date,string time)
        {
             
            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            List<Kliniek> Centrums = dataLayer.GetKlinieken(Categories, Patiënten);
            Kliniek centrum = Centrums.Where(x => x.Name == CentrumName).FirstOrDefault();
            
            Category category = Categories.Where(x => x.Name == categoryName).FirstOrDefault();
            Behandeling behandeling = category.Behandelingen.Where(x=> x.Name==behandelingName).FirstOrDefault();
            Specialist specialist = centrum.GetSpecialisten().Where(x => x.BSN == specialistBSN).FirstOrDefault();
            Patiënt patient = Patiënten.Where(x=> x.BSN== patiëntBSN).FirstOrDefault();
            Afspraak afspraak = new Afspraak(category, behandeling, "", AfspraakStatus.InBehandeling,
                DateTime.Now, DateTime.Parse(date), new Time(time), specialist, patient);
             Centrums.Where(x => x.Name == CentrumName).First().AddAfspraakToCentrum(afspraak);
            dataLayer.SaveAfspraak(Centrums);
            
            
        }

        public void RegisterBrief(Patiënt patiënt, VerwijsBrief brief)
        {
            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            if (Patiënten.Where(p => p.BSN != patiënt.BSN).Any())
            {
                patiënt.RegisterBrief(brief);
                Patiënten.Add(patiënt);
            }
            else
            {
                Patiënten.Where(p => p.BSN != patiënt.BSN)
                    .First().RegisterBrief(brief);

            }
        }
        public List<Kliniek> GetCentrums(Behandeling behandeling)
        {
            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            List<Kliniek> Centrums = dataLayer.GetKlinieken(Categories, Patiënten);
            return Centrums.Where(x => x.HaveToBehandeling(behandeling.Name) == true).ToList();
        }

        public List<KliniekViewModel> GetCentrumsMetVrijeTijden(string behandelingName)
        {
            List<KliniekViewModel> klinieks = new List<KliniekViewModel>();
            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            List<Kliniek> Centrums = dataLayer.GetKlinieken(Categories, Patiënten);
            foreach (var item in Centrums)
            {
                
                List<Agenda> times = item.CalculateVrijeTijd(behandelingName);
                List<KliniekAgendaViewModel> timesViewModel = new List<KliniekAgendaViewModel>();
                if (times.Count>0)
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
                    klinieks.Add(new KliniekViewModel(item.Name,details, item.Locatie, timesViewModel));
                }
            }
            return klinieks;

        }
      

    }
}
