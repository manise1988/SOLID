using EAfspraak.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Infrastructure;
using DTO = EAfspraak.Infrastructure.DTO;
using EAfspraak.Services.Domain;

namespace EAfspraak.Services.DataModel
{
    public class DomainModel
    {
        DataRepotisory dataRepository;

        public DomainModel(string dataPath)
        {
            dataRepository = new DataRepotisory(dataPath);
        }


        public List<Category> GetCategory()
        {
            List<Category> categories = new List<Category>();

            List<DTO.Category> dtoCategories = dataRepository.GetCategories();
            List<DTO.Behandeling> dtoBehandelingen = dataRepository.GetBehandelingen();
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
        public void SetCategory(List<Category> categories)
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
            dataRepository.SetCategory(dtoCategories);
            dataRepository.SetBehandeling(dtoBehandelings);



        }

        public List<Patiënt> GetPatiënten(List<Category> categories)
        {
            List<Patiënt> patiënten = new List<Patiënt>();
            List<DTO.Persoon> dtoPatienten = dataRepository.GetPersonen().Where(x => x.Role == "patient").ToList();
            List<DTO.VerwijsBrief> dtoBrieven = dataRepository.GetVerwijsBrieven();

            foreach (var item in dtoPatienten)
            {
                Patiënt patiënt = new Patiënt(item.BSN, item.FirstName, item.LastName,
                    item.Birthday, item.EmailAddress, item.Address);
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
        public void SetPersonen(List<Patiënt> patienten, List<Huisarts> huisartsen)
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
            dataRepository.SetPersonen(dtoPersonen);
            dataRepository.SetVerwijsBrieven(dtoBrieven);



        }

        public List<Huisarts> GetHuisarts()
        {
            List<Huisarts> huisartsen = new List<Huisarts>();
            List<DTO.Persoon> dtoHuisartsen = dataRepository.GetPersonen().Where(x => x.Role == "huisarts").ToList();


            foreach (var item in dtoHuisartsen)
            {

                huisartsen.Add(new Huisarts(item.BSN, item.FirstName, item.LastName,
                    item.Birthday));

            }



            return huisartsen;

        }


        public List<Centrum> GetCentrums(List<Category> categories, List<Patiënt> Patiënten)
        {
            List<Centrum> centrumList = new List<Centrum>();
            List<Behandeling> behandelingen = new List<Behandeling>();
            foreach (var itemCategories in categories)
            {
                behandelingen.AddRange(itemCategories.Behandelingen);
            }

            List<DTO.BehandelingAgenda> dtoBehandelingAgendaList = dataRepository.GetBehandelingAgendas();
            List<DTO.Afspraak> dtoAfspraken = dataRepository.GetAfspraken();
            List<DTO.Centrum> dtoCentra = dataRepository.GetCentrum();
            foreach (DTO.Centrum item in dtoCentra)
            {
                Centrum centrum = new Centrum(item.Name, item.Locatie);
                foreach (var itemSpecialist in item.Specialisten)
                {
                    Category category = categories.Where(x => x.Name == itemSpecialist.CategoryName).First();
                    Specialist specialist = new Specialist(itemSpecialist.BSN, itemSpecialist.FirstName,
                        itemSpecialist.LastName, category);
                    centrum.AddSpesialistToCentrum(specialist);
                }
                //foreach (long itemPatient in item.PatiëntenBSN)
                //{

                //    Patiënt patient = patiënts.Where(x => x.BSN == itemPatient).First();
                //    centrum.AddPatientToCentrum(patient);
                //}

                foreach (var itemBehandeling in item.BehandelingenName)
                {


                    Behandeling behandeling = behandelingen.Where(x => x.Name == itemBehandeling).First();
                    centrum.AddBehandelingToCentrum(behandeling);
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
                    centrum.AddAfspraakToCentrum(new Afspraak(category, behandeling, itemAfspraak.Details,
                        (AfspraakStatus)Enum.Parse(typeof(AfspraakStatus), itemAfspraak.AfspraakStatus),
                        itemAfspraak.RegisterDate, itemAfspraak.BehandelingDatum, new Time(itemAfspraak.BegintTime), specialist, patiënt)
                        );

                }

                centrumList.Add(centrum);
            }
            return centrumList;
        }

    }
}
