using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;


namespace EAfspraak.Domain.Verzender
{
    public class AfspraakReader 
    {
        IRepotisoryCategory iRepotisoryCategory;
        IRepotisoryKliniek iRepotisoryKliniek;
        IRepotisoryPersoon iRepotisoryPatiënt;
       
        public AfspraakReader(IRepotisoryCategory repotisoryCategory,
            IRepotisoryPersoon repotisoryPatiënt,
            IRepotisoryKliniek repotisoryKliniek)
        {
            iRepotisoryCategory = repotisoryCategory;  
            iRepotisoryKliniek = repotisoryKliniek;
            iRepotisoryPatiënt = repotisoryPatiënt;
        }

        public List<Category> GetCategories()
        {
           
            List<Category> Categories = iRepotisoryCategory.ReadData();
            return Categories;
        }
        public List<Huisarts> GetHuisartsen()
        {

            List<Huisarts> Huisartsen = iRepotisoryPatiënt.ReadHuisarts();
            return Huisartsen;
        }

        public List<Patiënt> GetPatienten()
        {
            //List<Category> Categories = dataLayer.GetCategory();
            return iRepotisoryPatiënt.ReadPatiënt();//.GetPatiënten(Categories);
        }
        public void MaakAfspraak(string categoryName, string behandelingName, string CentrumName, long patiëntBSN, long specialistBSN,
            DateTime date, Time time)
        {
            
            List<Category> Categories = iRepotisoryCategory.ReadData();
            List<Patiënt> Patiënten = iRepotisoryPatiënt.ReadPatiënt();//.GetPatiënten(Categories);
            List<Kliniek> Klinieken = iRepotisoryKliniek.ReadData();

            Kliniek kliniek = Klinieken.Where(x => x.Name == CentrumName).FirstOrDefault();
            Category category = Categories.Where(x => x.Name == categoryName).FirstOrDefault();
            IBehandeling behandeling = category.Behandelingen.Where(x => x.Name == behandelingName).FirstOrDefault();
            Specialist specialist = kliniek.Specialisten.Where(x => x.BSN == specialistBSN).FirstOrDefault();
            Patiënt patient = Patiënten.Where(x => x.BSN == patiëntBSN).FirstOrDefault();
            
            Afspraak afspraak = new Afspraak(category, behandeling, AfspraakStatus.InBehandeling,
                 date, time, specialist, patient);
            Klinieken.Where(x => x.Name == CentrumName).First().AddAfspraakToKliniek(afspraak);

            iRepotisoryKliniek.SaveAfspraak(kliniek,afspraak);


        }


        public List<Kliniek> GetKlinieken()
        {
            //List<Category> Categories = dataLayer.GetCategory();
            //List<Patiënt> Patiënten = dataLayer.GetPatiënten(Categories);
            //List<Kliniek> klinieken = dataLayer.GetKlinieken(Categories, Patiënten);
            List<Kliniek> klinieken = iRepotisoryKliniek.ReadData();
            klinieken.Sort();
            return klinieken;
        }

        public List<Kliniek> GetCentrumsMetVrijeTijden(string behandelingName)
        {
            //List<Category> Categories = iRepotisoryCategory.ReadData();
            //List<Patiënt> Patiënten = iRepotisoryPatiënt.ReadData();//.GetPatiënten(Categories);
            List<Kliniek> klinieken = iRepotisoryKliniek.ReadData();//.GetKlinieken(Categories, Patiënten);
           
            return klinieken;

        }


    }
}
