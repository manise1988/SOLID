using EAfspraak.Domain;
using EAfspraak.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Infrastructure
{
    public class RepotisoryKliniek : IRepotisoryKliniek
    {
        public List<Kliniek> ReadData()
        {
            DataRepotisory dataRepository = new DataRepotisory();
            List<Kliniek> centrumList = new List<Kliniek>();
            List<IBehandeling> behandelingen = new List<IBehandeling>();

            RepotisoryCategory repotisoryCategory = new RepotisoryCategory();
            List<Category> categories = repotisoryCategory.ReadData();

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
                    Vrij vakantie = new Vrij(DateTime.Parse(itemVakantie.Datum), itemVakantie.Datail,VrijType.Vakantie);
                    centrum.AddVakantieDagenToKliniek(vakantie);
                }

                foreach (var itemSpecialist in item.Specialisten)
                {
                    Category category = categories.Where(x => x.Name == itemSpecialist.CategoryName).First();
                    Specialist specialist = new Specialist(itemSpecialist.BSN, itemSpecialist.FirstName,
                        itemSpecialist.LastName, category);
                    if (itemSpecialist.Verlofs != null)
                    {
                        foreach (var itemVerlof in itemSpecialist.Verlofs)
                        {
                            specialist.AddVerlof(new Vrij(DateTime.Parse(itemVerlof.Datum), itemVerlof.Datail,VrijType.Verlof));

                        }
                    }
                  
                    centrum.AddSpesialistToKliniek(specialist);
                }


                foreach (var itemBehandeling in item.BehandelingenName)
                {


                    IBehandeling behandeling = behandelingen.Where(x => x.Name == itemBehandeling).First();
                    centrum.AddBehandelingToKliniek(behandeling);
                }
                foreach (var itemBehandelingAgenda in dtoBehandelingAgendaList.Where(x => x.CentrumName == item.Name).ToList())
                {
                    Specialist specialist = centrum.GetSpecialisten().Where(x => x.BSN == itemBehandelingAgenda.BSNSpecialist).First();

                    BehandelingAgenda behandelingAgenda = new BehandelingAgenda(specialist, (Werkdag)Enum.Parse(typeof(Werkdag), itemBehandelingAgenda.Werkdag),
                        new Time(itemBehandelingAgenda.BeginTime), new Time(itemBehandelingAgenda.EndTime));

                    centrum.RegisterBehandelingAgenda(behandelingAgenda);
                }
                RepotisoryPersoon repotisoryPatiënt = new RepotisoryPersoon();
                List<Patiënt> Patiënten = repotisoryPatiënt.ReadPatiënt();

                foreach (var itemAfspraak in dtoAfspraken)
                {
                    Specialist specialist = centrum.GetSpecialisten().Where(x => x.BSN == itemAfspraak.SpecialistBSN).First();
                    Patiënt patiënt = Patiënten.Where(x => x.BSN == itemAfspraak.PatientBSN).First();
                    Category category = categories.Where(x => x.Name == itemAfspraak.CategoryName).First();
                    IBehandeling behandeling = centrum.GetBehandelings().Where(x => x.Name == itemAfspraak.BehandelingName).First();
                    centrum.AddAfspraakToKliniek(new Afspraak(category, behandeling, itemAfspraak.Details,
                        (AfspraakStatus)Enum.Parse(typeof(AfspraakStatus), itemAfspraak.AfspraakStatus),
                       DateTime.Parse(itemAfspraak.RegisterDate), DateTime.Parse(itemAfspraak.BehandelingDatum), new Time(itemAfspraak.BeginTime), specialist, patiënt)
                        );

                }

                centrumList.Add(centrum);
            }
            return centrumList;
        }

        public void SaveAfspraak(List<Kliniek> data)
        {
            DataRepotisory dataRepository = new DataRepotisory();
            List<DTO.Kliniek> dtoCentrums = new List<DTO.Kliniek>();
            List<DTO.Afspraak> dtoAfspraaken = new List<DTO.Afspraak>();
            foreach (Kliniek kliniek in data)
            {
                foreach (var afspraak in kliniek.GetAfspraken())
                {
                    dtoAfspraaken.Add(new DTO.Afspraak(afspraak.Category.Name, afspraak.Behandeling.Name,
                        afspraak.Details, afspraak.AfspraakStatus.ToString(), afspraak.RegisterDate.ToShortDateString(),
                        afspraak.Datum.ToShortDateString(), afspraak.BeginTime.GetTime(), afspraak.Patiënt.BSN,
                        afspraak.Specialist.BSN, kliniek.Name));
                }

            }
            dataRepository.SaveData(dtoAfspraaken, "Afspraak");
        }
    }
}
