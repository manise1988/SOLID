using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Infrastructure;
using DTO = EAfspraak.Infrastructure.DTO;

using EAfspraak.Domain;

namespace EAfspraak.Domain.Verzender
{
    public class AfspraakReader 
    {
        private List<Category> Categories { get; set; }
        private List<Huisarts> Huisartsen { get; set; }

        DataReader dataLayer;
        public AfspraakReader(string dataPath)
        {
            dataLayer = new DataReader(dataPath);

            Categories = dataLayer.GetCategory();
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
        public void MaakAfspraak(string categoryName, string behandelingName, string CentrumName, long patiëntBSN, long specialistBSN,
            DateTime date, Time time)
        {

            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            List<Kliniek> Centrums = dataLayer.GetKlinieken(Categories, Patiënten);
            Kliniek centrum = Centrums.Where(x => x.Name == CentrumName).FirstOrDefault();

            Category category = Categories.Where(x => x.Name == categoryName).FirstOrDefault();
            Behandeling behandeling = category.Behandelingen.Where(x => x.Name == behandelingName).FirstOrDefault();
            Specialist specialist = centrum.GetSpecialisten().Where(x => x.BSN == specialistBSN).FirstOrDefault();
            Patiënt patient = Patiënten.Where(x => x.BSN == patiëntBSN).FirstOrDefault();
            Afspraak afspraak = new Afspraak(category, behandeling, "", AfspraakStatus.InBehandeling,
                DateTime.Now, date, time, specialist, patient);
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
        public List<Kliniek> GetCentrums()
        {
            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            List<Kliniek> Centrums = dataLayer.GetKlinieken(Categories, Patiënten);
            return Centrums;//.Where(x => x.HaveToBehandeling(behandeling.Name) == true).ToList();
        }

        public List<Kliniek> GetCentrumsMetVrijeTijden(string behandelingName)
        {
           
            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            List<Kliniek> Centrums = dataLayer.GetKlinieken(Categories, Patiënten);
           
            return Centrums;

        }


    }
}
