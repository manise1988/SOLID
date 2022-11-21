using EAfspraak.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Infrastructure;
using DTO = EAfspraak.Infrastructure.DTO;
using EAfspraak.Domain;
using EAfspraak.Infrastructure.DTO;

namespace EAfspraak.Domain.Verzender
{
    public class DataReader
    {
        DataRepotisory dataRepository;

        public DataReader()
        {
            dataRepository = new DataRepotisory();
        }


        public List<Category> GetCategory()
        {
            List<Category> categories = new List<Category>();

            List<DTO.Category> dtoCategories = dataRepository.ReadData<List<DTO.Category>>("Category");
            List<DTO.Behandeling> dtoBehandelingen = dataRepository.ReadData<List<DTO.Behandeling>>("Behandeling");
            foreach (DTO.Category item in dtoCategories)
            {
                Category category = new Category(item.Name);
                foreach (DTO.Behandeling itemBehandeling in dtoBehandelingen.Where(x => x.CategoryName == item.Name))
                {
                    Behandeling behandeling = new Behandeling(itemBehandeling.Name,
                        new Time(itemBehandeling.DurationTime), itemBehandeling.IsVerwijsbriefNodig);
                    category.Behandelingen.Add(behandeling);

                }
                categories.Add(category);


            }
            return categories;

        }
        public void SaveCategory(List<Category> categories)
        {

            List<DTO.Category> dtoCategories = new List<DTO.Category>();
            List<DTO.Behandeling> dtoBehandelings = new List<DTO.Behandeling>();
            foreach (var item in categories)
            {

                dtoCategories.Add(new DTO.Category(item.Name));
                foreach (var itemBehandeling in item.Behandelingen)
                {
                    dtoBehandelings.Add(new DTO.Behandeling(itemBehandeling.Name,
                        itemBehandeling.DurationTime.GetTime().ToString(), itemBehandeling.IsVerwijsbriefNodig, item.Name));


                }


            }
            dataRepository.SaveData(dtoCategories, "Category");
            dataRepository.SaveData(dtoBehandelings, "Behandeling");



        }

        public List<Patiënt> GetPatiënten(List<Category> categories)
        {
            List<Patiënt> patiënten = new List<Patiënt>();
            List<DTO.Persoon> dtoPatienten = dataRepository.ReadData<List<DTO.Persoon>>("Persoon").Where(x => x.Role == "patient").ToList();
            List<DTO.VerwijsBrief> dtoBrieven = dataRepository.ReadData<List<DTO.VerwijsBrief>>("VerwijsBrief");

            foreach (var item in dtoPatienten)
            {
                Patiënt patiënt = new Patiënt(item.BSN, item.FirstName, item.LastName,
                    item.Birthday, item.EmailAddress, item.Address);
                if(dtoBrieven!=null)
                foreach (var itemBrieven in dtoBrieven.Where(x => x.Bsn == item.BSN).ToList())
                {
                    Category category = categories.Where(x => x.Name == itemBrieven.CategoryName).First();
                    Behandeling behandeling = category.Behandelingen.Where(x => x.Name == itemBrieven.BehandelingName).First();

                    patiënt.RegisterBrief(new VerwijsBrief(category, behandeling, itemBrieven.Details,
                        (BriefStatus)Enum.Parse(typeof(BriefStatus), itemBrieven.BriefStatus),
                       itemBrieven.RegisterDate));

                }

                patiënten.Add(patiënt);

            }



            return patiënten;

        }
        public void SavePersonen(List<Patiënt> patienten, List<Huisarts> huisartsen)
        {

            List<DTO.Persoon> dtoPersonen = new List<DTO.Persoon>();
            List<DTO.VerwijsBrief> dtoBrieven = new List<DTO.VerwijsBrief>();
            foreach (var item in patienten)
            {

                dtoPersonen.Add(new DTO.Persoon(item.BSN, item.FirstName, item.LastName, item.Birthday, item.EmailAddress, item.Address, "patient"));
                foreach (var itemBrief in item.Brieven)
                {
                    dtoBrieven.Add(new DTO.VerwijsBrief(item.BSN, itemBrief.Category.Name, itemBrief.Behandeling.Name, itemBrief.Details,
                        itemBrief.BriefStatus.ToString(), itemBrief.RegisterDate));


                }


            }

            foreach (var item in huisartsen)
            {

                dtoPersonen.Add(new DTO.Persoon(item.BSN, item.FirstName, item.LastName, item.Birthday, "", "", "huisarts"));


            }
            dataRepository.SaveData(dtoPersonen, "Persoon");
            dataRepository.SaveData(dtoBrieven, "VerwijsBrief");



        }

        public List<Huisarts> GetHuisarts()
        {
            List<Huisarts> huisartsen = new List<Huisarts>();
            List<DTO.Persoon> dtoHuisartsen = dataRepository.ReadData<List<DTO.Persoon>>("Persoon").Where(x => x.Role == "huisarts").ToList();


            foreach (var item in dtoHuisartsen)
            {

                huisartsen.Add(new Huisarts(item.BSN, item.FirstName, item.LastName,
                    item.Birthday));

            }



            return huisartsen;

        }


        public List<Kliniek> GetKlinieken(List<Category> categories, List<Patiënt> Patiënten)
        {
            List<Kliniek> centrumList = new List<Kliniek>();
            List<Behandeling> behandelingen = new List<Behandeling>();
            foreach (var itemCategories in categories)
            {
                behandelingen.AddRange(itemCategories.Behandelingen);
            }

            List<DTO.BehandelingAgenda> dtoBehandelingAgendaList = dataRepository.ReadData<List<DTO.BehandelingAgenda>>("BehandelingAgenda");
            List<DTO.Afspraak> dtoAfspraken = dataRepository.ReadData<List<DTO.Afspraak>>("Afspraak");
            List<DTO.Kliniek> dtoCentra = dataRepository.ReadData<List<DTO.Kliniek>>("Kliniek");
            foreach (DTO.Kliniek item in dtoCentra)
            {
                Kliniek centrum = new Kliniek(item.Name, item.Locatie);
                foreach (var itemSpecialist in item.Specialisten)
                {
                    Category category = categories.Where(x => x.Name == itemSpecialist.CategoryName).First();
                    Specialist specialist = new Specialist(itemSpecialist.BSN, itemSpecialist.FirstName,
                        itemSpecialist.LastName, category);
                    centrum.AddSpesialistToKliniek(specialist);
                }


                foreach (var itemBehandeling in item.BehandelingenName)
                {


                    Behandeling behandeling = behandelingen.Where(x => x.Name == itemBehandeling).First();
                    centrum.AddBehandelingToKliniek(behandeling);
                }
                foreach (var itemBehandelingAgenda in dtoBehandelingAgendaList.Where(x => x.CentrumName == item.Name).ToList())
                {
                    Specialist specialist = centrum.GetSpecialisten().Where(x => x.BSN == itemBehandelingAgenda.BSNSpecialist).First();

                    BehandelingAgenda behandelingAgenda = new BehandelingAgenda(specialist, (Werkdag)Enum.Parse(typeof(Werkdag), itemBehandelingAgenda.Werkdag),
                        new Time(itemBehandelingAgenda.BeginTime), new Time(itemBehandelingAgenda.EndTime));

                    centrum.RegisterBehandelingAgenda(behandelingAgenda);
                }

                foreach (var itemAfspraak in dtoAfspraken)
                {
                    Specialist specialist = centrum.GetSpecialisten().Where(x => x.BSN == itemAfspraak.SpecialistBSN).First();
                    Patiënt patiënt = Patiënten.Where(x => x.BSN == itemAfspraak.PatientBSN).First();
                    Category category = categories.Where(x => x.Name == itemAfspraak.CategoryName).First();
                    Behandeling behandeling = centrum.GetBehandelings().Where(x => x.Name == itemAfspraak.BehandelingName).First();
                    centrum.AddAfspraakToKliniek(new Afspraak(category, behandeling, itemAfspraak.Details,
                        (AfspraakStatus)Enum.Parse(typeof(AfspraakStatus), itemAfspraak.AfspraakStatus),
                       DateTime.Parse( itemAfspraak.RegisterDate), DateTime.Parse(itemAfspraak.BehandelingDatum), new Time(itemAfspraak.BeginTime), specialist, patiënt)
                        );

                }

                centrumList.Add(centrum);
            }
            return centrumList;
        }

        public void SaveAfspraak(List<Kliniek> centrums)
        {
            List<DTO.Kliniek> dtoCentrums = new List<DTO.Kliniek>();
            List<DTO.Afspraak> dtoAfspraaken = new List<DTO.Afspraak>();
            foreach (Kliniek centrum in centrums)
            {
                foreach (var afspraak in centrum.GetAfspraken())
                {
                    dtoAfspraaken.Add(new DTO.Afspraak(afspraak.Category.Name, afspraak.Behandeling.Name,
                        afspraak.Details, afspraak.AfspraakStatus.ToString(), afspraak.RegisterDate.ToShortDateString(),
                        afspraak.BehandelingDatum.ToShortDateString(), afspraak.BeginTime.GetTime(), afspraak.Patiënt.BSN,
                        afspraak.Specialist.BSN, centrum.Name));
                }

            }
            dataRepository.SaveData(dtoAfspraaken,"Afspraak");

        }
    }
}
