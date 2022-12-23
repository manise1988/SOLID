using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EAfspraak.Infrastructure
{
    public class RepotisoryManager : IRepotisoryData
    {
       
        public List<Category> ReadCategory()
        {
            Repotisory dataRepository = new Repotisory();
            List<Category> categoryList = dataRepository.ReadData<List<Category>>("Category");

           
            return categoryList;
           

        }
        public Category ReadCategoryByNaam(string categoryNaam)
        {
            Repotisory dataRepository = new Repotisory();
            List<Category> categoryList = dataRepository.ReadData<List<Category>>("Category");

            if (categoryList != null)
                if (categoryList.Count > 0)
                    if (categoryList.Where(x => x.Name == categoryNaam).Any())
                        return categoryList.Where(x => x.Name == categoryNaam).First();

            return default;


        }
        public IBehandeling ReadBehandelingByNaam(string behandelingName)
        {
            Repotisory dataRepository = new Repotisory();

            List<Category> dataCategories = dataRepository.ReadData<List<Category>>("Category");

            if (dataCategories != null)
                if (dataCategories.Count > 0)
                {
                    foreach (Category item in dataCategories)
                    {
                        IBehandeling behandeling = item.Behandelingen.Where(x => x.Name == behandelingName).First();
                        return behandeling;
                    }
                }

            return null;
        }
        public List<Kliniek> ReadKliniek()
        {
            Repotisory dataRepository = new Repotisory();
            List<Kliniek> dataKlinieken = dataRepository.ReadData<List<Kliniek>>("Kliniek");
           
            foreach (var item in dataKlinieken)
            {
                foreach (var itemSpesialist in item.Specialisten)
                {

                    itemSpesialist.Category = ReadCategoryByNaam(itemSpesialist.Category.Name);                    

                }
            }
            return dataKlinieken;
           
        }
        public Kliniek ReadKliniekByNaam(string kliniekNaam) 
        {

            Repotisory dataRepository = new Repotisory();
            List<Kliniek> dataKlinieken = dataRepository.ReadData<List<Kliniek>>("Kliniek");
            if (dataKlinieken != null)
                if (dataKlinieken.Count > 0)
                    if (dataKlinieken.Where(x => x.Name == kliniekNaam).Any())
                        return dataKlinieken.Where(x => x.Name == kliniekNaam).First();

            return default;

        }
        public Specialist ReadSpesialistByBSN(string KlinkNaam,long bsn) 
        {
            return default;

        }
        public List<Patiënt> ReadPatiënt()
        {
            

            
            Repotisory dataRepository = new Repotisory();
          
            List<Patiënt> patiënten = dataRepository.ReadData<List<Patiënt>>("Patiënt").ToList();

            return patiënten;
        }
        public Patiënt ReadPatiëntByBSN(long bsn)
        {



            Repotisory dataRepository = new Repotisory();

            List<Patiënt> patiënten = dataRepository.ReadData<List<Patiënt>>("Patiënt").ToList();

            if (patiënten != null)
                if (patiënten.Count > 0)
                    if(patiënten.Where(x => x.BSN == bsn).Any())
                        return patiënten.Where(x => x.BSN == bsn).First();
                
            return default;
        }

        public void SaveAfspraak( Kliniek kliniek)
        {
            Repotisory dataRepository = new Repotisory();
            dataRepository.SaveData(kliniek, "Kliniek");
        }
    
    }
}
