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
        DataReader dataLayer;
        public AfspraakReader()
        {
            dataLayer = new DataReader();

        }

        public List<Category> GetCategories()
        {
            List<Category> Categories = dataLayer.GetCategory();
            return Categories;
        }
        public List<Huisarts> GetHuisartsen()
        {
            List<Huisarts> Huisartsen = dataLayer.GetHuisarts();
            return Huisartsen;
        }

        public List<Patiënt> GetPatienten()
        {
            List<Category> Categories = dataLayer.GetCategory();
            return dataLayer.GetPatiënten(Categories);
        }
        public void MaakAfspraak(string categoryName, string behandelingName, string CentrumName, long patiëntBSN, long specialistBSN,
            DateTime date, Time time)
        {
            List<Category> Categories = dataLayer.GetCategory();
            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            List<Kliniek> Klinieken = dataLayer.GetKlinieken(Categories, Patiënten);
           
            Kliniek kliniek = Klinieken.Where(x => x.Name == CentrumName).FirstOrDefault();
            Category category = Categories.Where(x => x.Name == categoryName).FirstOrDefault();
            Behandeling behandeling = category.Behandelingen.Where(x => x.Name == behandelingName).FirstOrDefault();
            Specialist specialist = kliniek.GetSpecialisten().Where(x => x.BSN == specialistBSN).FirstOrDefault();
            Patiënt patient = Patiënten.Where(x => x.BSN == patiëntBSN).FirstOrDefault();
            
            IntakeAfspraak afspraak = new IntakeAfspraak(category, behandeling, "", AfspraakStatus.InBehandeling,
                DateTime.Now, date, time, specialist, patient);
            Klinieken.Where(x => x.Name == CentrumName).First().AddAfspraakToKliniek(afspraak);

            dataLayer.SaveAfspraak(Klinieken);


        }

        public void RegisterBrief(Patiënt patiënt, VerwijsBrief brief)
        {
            List<Category> Categories = dataLayer.GetCategory();
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
        public List<Kliniek> GetKlinieken()
        {
            List<Category> Categories = dataLayer.GetCategory();
            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            List<Kliniek> klinieken = dataLayer.GetKlinieken(Categories, Patiënten);
            klinieken.Sort();
            return klinieken;
        }

        public List<Kliniek> GetCentrumsMetVrijeTijden(string behandelingName)
        {
            List<Category> Categories = dataLayer.GetCategory();
            List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            List<Kliniek> Centrums = dataLayer.GetKlinieken(Categories, Patiënten);
           
            return Centrums;

        }


    }
}
