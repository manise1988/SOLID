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
        public List<Patiënt> Patiënts { get; set; }

        public AfspraakService()
        {
            DataLayerServices dataLayer = new DataLayerServices();

            Categories = dataLayer.GetCategory();
            Centrums = dataLayer.GetCentrums(Categories);
            Patiënts = dataLayer.GetPatiënten(Centrums,Categories);

           

        }
        public Brief MaakAfspraak()
        {
            
            throw new NotImplementedException();
        }

        public void RegisterBrief(Patiënt patiënt, Brief brief)
        {
            if (Patiënts.Where(p => p.BSN != patiënt.BSN).Any())
            {
                patiënt.RegisterBrief(brief);
                Patiënts.Add(patiënt);
            }
            else
            {
                Patiënts.Where(p => p.BSN != patiënt.BSN)
                    .First().RegisterBrief(brief);

            }
        }
        public  List<Centrum> GetCentrums(Behandeling behandeling)
        {
            return Centrums.Where(x=> x.HaveToBehandeling(behandeling.Name)==true).ToList();
        }
        public List<Time> CalculateWachtLijst(string centrumName, long spesialistBSN,string categoryName, string behandelingName,DateTime selectedDay)
        {
            List<Brief> briefList = new List<Brief>();
            foreach (var item in Patiënts)
            {
                briefList.AddRange(item.Brieven.Where(x => x.Centrum.Name == centrumName).ToList());
            }
            
            List<Time> times =  Centrums.Where(x=> x.Name== centrumName).First().CalculateVrijeTijdFromAgenda(spesialistBSN,behandelingName, selectedDay);

            if (briefList.Count > 0)
            {

                foreach (var item in briefList.Where(x => x.BehandelingDatum == selectedDay
                && x.Category.Name == categoryName &&
                x.Specialist.BSN == spesialistBSN &&
                x.BriefStatus == BriefStatus.AanDeBeurt 
                ).ToList())
                {
                    //Algoritme
                   // endtime = item.BegintTime+item.Behandeling.DurationTime

                } 

            }


                return times;
            
        }

    }
}
