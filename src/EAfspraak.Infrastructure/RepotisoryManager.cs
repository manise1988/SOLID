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
        public IBehandeling behandelingByNaam(string behandelingName)
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

        public List<Category> ReadDataCategory()
        {
            Repotisory dataRepository = new Repotisory();


          //  List<Data.Category> dataCategories = dataRepository.ReadData<List<Data.Category>>("Category");
            
            List<Category> categoryList = dataRepository.ReadData<List<Category>>("Category");

           
            return categoryList;
           

        }

        public List<Kliniek> ReadDataKliniek()
        {
            Repotisory dataRepository = new Repotisory();
            List<Kliniek> dataKlinieken = dataRepository.ReadData<List<Kliniek>>("Kliniek");
            return dataKlinieken;
           
        }

        public List<Patiënt> ReadPatiënt()
        {
            

            
            Repotisory dataRepository = new Repotisory();
          
            List<Patiënt> patiënten = dataRepository.ReadData<List<Patiënt>>("Patiënt").ToList();

            return patiënten;
        }

        public void SaveAfspraak(Kliniek kliniek, Afspraak afspraak)
        {
            Repotisory dataRepository = new Repotisory();
            EAfspraak.Infrastructure.Data.Afspraak dataAfspraak = new
             EAfspraak.Infrastructure.Data.Afspraak(afspraak.Category.Name, afspraak.Behandeling.Name,
                        afspraak.AfspraakStatus.ToString(),
                        afspraak.Datum.ToShortDateString(), afspraak.BehandelingTime.GetTime(), afspraak.Patiënt.BSN,
                        afspraak.Specialist.BSN, kliniek.Name);



            dataRepository.SaveData(dataAfspraak, "Afspraak");
        }
    
    }
}
