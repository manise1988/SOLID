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
        public List<Category> Categories { get; set; }
        public List<Centrum> Centrums { get; set; }
        public List<Patiënt> Patiënten { get; set; }
        public List<Huisarts> Huisartsen { get; set; }
        public AfspraakService(string dataPath)
        {
            DataLayerServices dataLayer = new DataLayerServices(dataPath);

            Categories = dataLayer.GetCategory();
            Patiënten = dataLayer.GetPatiënten(Categories);
            Centrums = dataLayer.GetCentrums(Categories,Patiënten);

            Huisartsen = dataLayer.GetHuisarts();

           

        }
        public VerwijsBrief MaakAfspraak()
        {
            
            throw new NotImplementedException();
        }

        public void RegisterBrief(Patiënt patiënt, VerwijsBrief brief)
        {
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
            return Centrums.Where(x=> x.HaveToBehandeling(behandeling.Name)==true).ToList();
        }
        public List<Time> CalculateWachtLijst(string centrumName, long spesialistBSN,string categoryName, string behandelingName,DateTime selectedDay)
        {
           
            List<Time> times =  Centrums.Where(x=> x.Name== centrumName).First().CalculateVrijeTijdFromAgenda(spesialistBSN, categoryName, behandelingName, selectedDay);

            return times;
            
        }

    }
}
