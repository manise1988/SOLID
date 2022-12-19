using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
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
            List<Category> categories = new List<Category>();

            List<DTO.Category> dtoCategories = dataRepository.ReadData<List<DTO.Category>>("Category");
            List<DTO.Behandeling> dtoBehandelingen = dataRepository.ReadData<List<DTO.Behandeling>>("Behandeling");
            foreach (DTO.Category item in dtoCategories)
            {
                Category category = new Category(item.Name);
                foreach (DTO.Behandeling itemBehandeling in dtoBehandelingen.Where(x => x.CategoryName == item.Name))
                {
                    if (itemBehandeling.Name == behandelingName)
                    {
                        Behandeling behandeling = new Behandeling(itemBehandeling.Name,
                            new Time(itemBehandeling.DurationTime), itemBehandeling.BehandelingGroep);
                        category.Behandelingen.Add(behandeling);

                        return behandeling;
                    }

                }
                
            }
            return null;
        }

        public List<Category> ReadDataCategory()
        {
            Repotisory dataRepository = new Repotisory();
            List<Category> categories = new List<Category>();

            List<DTO.Category> dtoCategories = dataRepository.ReadData<List<DTO.Category>>("Category");
            List<DTO.Behandeling> dtoBehandelingen = dataRepository.ReadData<List<DTO.Behandeling>>("Behandeling");
            foreach (DTO.Category item in dtoCategories)
            {
                Category category = new Category(item.Name);
                foreach (DTO.Behandeling itemBehandeling in dtoBehandelingen.Where(x => x.CategoryName == item.Name))
                {

                    Behandeling behandeling = new Behandeling(itemBehandeling.Name,
                        new Time(itemBehandeling.DurationTime), itemBehandeling.BehandelingGroep);
                    category.Behandelingen.Add(behandeling);

                }
                categories.Add(category);
            }
            return categories;
        }

        public List<Kliniek> ReadDataKliniek()
        {
            Repotisory dataRepository = new Repotisory();
            List<Kliniek> centrumList = new List<Kliniek>();
            List<IBehandeling> behandelingen = new List<IBehandeling>();

            RepotisoryManager repotisory = new RepotisoryManager();
            List<Category> categories = repotisory.ReadDataCategory();

            foreach (var itemCategories in categories)
            {
                behandelingen.AddRange(itemCategories.Behandelingen);
            }

            List<DTO.BehandelingAgenda> dtoBehandelingAgendaList = dataRepository.ReadData<List<DTO.BehandelingAgenda>>("BehandelingAgenda");
            List<DTO.Afspraak> dtoAfspraken = dataRepository.ReadData<List<DTO.Afspraak>>("Afspraak");
            List<DTO.Kliniek> dtoCentra = dataRepository.ReadData<List<DTO.Kliniek>>("Kliniek");
            foreach (DTO.Kliniek item in dtoCentra)
            {
                KliniekSetting zoekBereik = new KliniekSetting(item.ZoekBereikInDag);
                Kliniek centrum = new Kliniek(item.Name, item.Locatie, zoekBereik);
                foreach (var itemVakantie in item.Vakanties)
                {
                    GeslotenDagen vakantie = new GeslotenDagen(DateTime.Parse(itemVakantie.Datum), itemVakantie.Datail);
                    centrum.AddVakantieDagenToKliniek(vakantie);
                }

                foreach (var itemSpecialist in item.Specialisten)
                {
                    Category category = categories.Where(x => x.Name == itemSpecialist.CategoryName).First();
                    Specialist specialist = new Specialist(itemSpecialist.BSN, itemSpecialist.FirstName,
                        itemSpecialist.LastName, category);


                    centrum.AddSpesialistToKliniek(specialist);
                }


                foreach (var itemBehandeling in item.BehandelingenName)
                {


                    IBehandeling behandeling = behandelingen.Where(x => x.Name == itemBehandeling).First();
                    centrum.AddBehandelingToKliniek(behandeling);
                }
                foreach (var itemBehandelingAgenda in dtoBehandelingAgendaList.Where(x => x.CentrumName == item.Name).ToList())
                {
                    Specialist specialist = centrum.Specialisten.Where(x => x.BSN == itemBehandelingAgenda.BSNSpecialist).First();

                    BehandelingAgenda behandelingAgenda = new BehandelingAgenda(specialist, (Werkdag)Enum.Parse(typeof(Werkdag), itemBehandelingAgenda.Werkdag),
                        new Time(itemBehandelingAgenda.BeginTime), new Time(itemBehandelingAgenda.EndTime));

                    centrum.RegisterBehandelingAgenda(behandelingAgenda);
                }
                RepotisoryManager repotisoryPatiënt = new RepotisoryManager();
                List<Patiënt> Patiënten = repotisoryPatiënt.ReadPatiënt();

                if (dtoAfspraken != null)
                    foreach (var itemAfspraak in dtoAfspraken)
                    {
                        Specialist specialist = centrum.Specialisten.Where(x => x.BSN == itemAfspraak.SpecialistBSN).First();
                        Patiënt patiënt = Patiënten.Where(x => x.BSN == itemAfspraak.PatientBSN).First();
                        Category category = categories.Where(x => x.Name == itemAfspraak.CategoryName).First();
                        IBehandeling behandeling = centrum.Behandelingen.Where(x => x.Name == itemAfspraak.BehandelingName).First();
                        centrum.AddAfspraakToKliniek(new Afspraak(category, behandeling,
                            (AfspraakStatus)Enum.Parse(typeof(AfspraakStatus), itemAfspraak.AfspraakStatus),
                            DateTime.Parse(itemAfspraak.BehandelingDatum), new Time(itemAfspraak.BeginTime), specialist, patiënt)
                            );

                    }

                centrumList.Add(centrum);
            }
            return centrumList;
        }

        public List<Patiënt> ReadPatiënt()
        {
            List<Patiënt> patiënten = new List<Patiënt>();

            RepotisoryManager repotisory = new RepotisoryManager();
            List<Category> categories = repotisory.ReadDataCategory();

            Repotisory dataRepository = new Repotisory();
            List<DTO.Persoon> dtoPatienten = dataRepository.ReadData<List<DTO.Persoon>>("Persoon").ToList();

            foreach (var item in dtoPatienten)
            {
                Patiënt patiënt = new Patiënt(item.BSN, item.FirstName, item.LastName,
                    DateTime.Parse(item.Birthday));

                patiënten.Add(patiënt);

            }



            return patiënten;
        }

        public void SaveAfspraak(Kliniek kliniek, Afspraak afspraak)
        {
            Repotisory dataRepository = new Repotisory();
            DTO.Afspraak dtoAfspraak = new
             DTO.Afspraak(afspraak.Category.Name, afspraak.Behandeling.Name,
                        afspraak.AfspraakStatus.ToString(),
                        afspraak.Datum.ToShortDateString(), afspraak.BehandelingTime.GetTime(), afspraak.Patiënt.BSN,
                        afspraak.Specialist.BSN, kliniek.Name);



            dataRepository.SaveData(dtoAfspraak, "Afspraak");
        }
    
    }
}
