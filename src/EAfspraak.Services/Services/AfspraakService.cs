using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Infrastructure;
using DTO = EAfspraak.Infrastructure.DTO;


using EAfspraak.Services.Domain;
namespace EAfspraak.Services.Services
{
    public class AfspraakService : IAfspraakService
    {
        private List<Category> Categories { get; set; }
        private List<Huisarts> Huisartsen { get; set; }

        DataLayerServices dataLayer;
        public AfspraakService(string dataPath)
        {
            dataLayer = new DataLayerServices(dataPath);

            Categories = dataLayer.GetCategory();
            //Patiënten = dataLayer.GetPatiënten(Categories);
            //Centrums = dataLayer.GetCentrums(Categories,Patiënten);

            Huisartsen = dataLayer.GetHuisarts();

           

        }

        public List<Category> GetCategories()
        {
            return Categories;
        }
        public List<Huisarts> GetHuisartsen()
        {
            return Huisartsen;
        }

        public List<Patiënt> GetPatienten()
        {
            return dataLayer.GetPatiënten(Categories); 
        }
        public VerwijsBrief MaakAfspraak()
        {
            
            throw new NotImplementedException();
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
        public  List<Centrum> GetCentrums(Behandeling behandeling)
        {
            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
           List<Centrum> Centrums = dataLayer.GetCentrums(Categories, Patiënten);
            return Centrums.Where(x=> x.HaveToBehandeling(behandeling.Name)==true).ToList();
        }

        public List<Centrum> GetCentrums(string behandelingName)
        {
            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            List<Centrum> Centrums = dataLayer.GetCentrums(Categories, Patiënten);
            foreach (var item in Centrums)
            {
                List<Time> times = item.CalculateVrijeTijd(behandelingName);
            }
            return Centrums;

        }
        public List<Time> CalculateWachtLijst(string centrumName, long spesialistBSN,string categoryName, string behandelingName,DateTime selectedDay)
        {
            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            List<Centrum> Centrums = dataLayer.GetCentrums(Categories, Patiënten);
            List<Time> times =  Centrums.Where(x=> x.Name== centrumName).First().CalculateVrijeTijdFromAgenda(spesialistBSN, categoryName, behandelingName, selectedDay);

            return times;
            
        }

    }
}
