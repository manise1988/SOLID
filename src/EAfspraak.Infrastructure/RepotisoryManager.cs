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

            List<Data.Category> dataCategories = dataRepository.ReadData<List<Data.Category>>("Category");

            List<Category> categoryList = new List<Category>();
            foreach (var item in dataCategories)
            {
                Behandeling behandeling = item.Behandelingen.Where(x=>x.Name==behandelingName).First();
                return behandeling;
            }


            return null;
        }

        public List<Category> ReadDataCategory()
        {
            Repotisory dataRepository = new Repotisory();
            
            List<Data.Category> dataCategories = dataRepository.ReadData<List<Data.Category>>("Category");
            
            List<Category> categoryList = new List<Category>();
            foreach (var item in dataCategories)
                categoryList.Add(new Category(item.Name,item.Behandelingen));

            return categoryList;
           

        }

        public List<Kliniek> ReadDataKliniek()
        {
            Repotisory dataRepository = new Repotisory();
            List<Category> categories = ReadDataCategory();
            List<Data.Kliniek> dataKlinieken = dataRepository.ReadData<List<Data.Kliniek>>("Kliniek");
            List<Kliniek> kliniekList = new List<Kliniek>();
            foreach (var item in dataKlinieken)
            {
                Kliniek kliniek = new Kliniek(item.Name, item.Locatie, item.KliniekSetting,item.Behandelingen,item.GeslotenDagen);
                foreach (var itemSpecialist in item.Specialisten)
                {
                    Category category = categories.Where(x => x.Name == itemSpecialist.Category.Name).First();
                    Specialist specialist = new Specialist(itemSpecialist.BSN, itemSpecialist.FirstName,
                        itemSpecialist.LastName, category);
                    kliniek.AddSpesialistToKliniek(specialist);
                }

                foreach (var itemBehandelingAgenda in item.BehandelingAgendas)
                {
                    Specialist specialist = kliniek.Specialisten.Where(x => x.BSN == itemBehandelingAgenda.Specialist.BSN).First();

                    BehandelingAgenda behandelingAgenda = new BehandelingAgenda(specialist, (Werkdag)Enum.Parse(typeof(Werkdag), itemBehandelingAgenda.Werkdag),
                        new Time(itemBehandelingAgenda.BeginTime), new Time(itemBehandelingAgenda.EndTime));

                    kliniek.RegisterBehandelingAgenda(behandelingAgenda);
                }

                kliniekList.Add(kliniek);
            }
            return kliniekList;
           
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
