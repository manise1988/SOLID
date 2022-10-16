using EAfspraak.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAfspraak.Infrastructure;
using DTO = EAfspraak.Infrastructure.DTO;
using EAfspraak.Services.Domain;

namespace EAfspraak.Services.Services
{
    public class DataLayerServices
    {
        DataRepotisory dataRepository = new DataRepotisory();
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
            
            List<DTO.Category> dtoCategories=new List<DTO.Category>();
            List<DTO.Behandeling> dtoBehandelings = new List<DTO.Behandeling>();
            foreach (var item in categories)
            {
                
                dtoCategories.Add(new DTO.Category(item.Name));
                foreach (var itemBehandeling in item.Behandelingen)
                {
                    dtoBehandelings.Add( new DTO.Behandeling(itemBehandeling.Name,
                        itemBehandeling.DurationTime.GetTime().ToString(), itemBehandeling.IsVerwijsbriefNodig, item.Name));

                   
                }
              

            }
            dataRepository.SetCategory(dtoCategories);
            dataRepository.SetBehandeling(dtoBehandelings);



        }

        public List<Patiënt> GetPatiënten(List<Centrum> centrums,List<Category> categories)
        {
            List<Patiënt> patiënten = new List<Patiënt>();
            List<DTO.Patiënt> dtoPatienten = dataRepository.GetPatiënt();
            List<DTO.Brief> dtoBrieven =dataRepository.GetBrieven();

            foreach (var item in dtoPatienten)
            {
                Patiënt patiënt = new Patiënt(item.BSN, item.FirstName, item.LastName,
                    item.Birthday, item.EmailAddress, item.Address);
                foreach (var itemBrieven in dtoBrieven.Where(x=> x.Bsn == item.BSN).ToList())
                {
                    Category category = categories.Where(x => x.Name == itemBrieven.CategoryName).First();
                    Behandeling behandeling = category.Behandelingen.Where(x => x.Name == itemBrieven.BehandelingName).First();
                    Centrum centrum = centrums.Where(x=> x.Name== itemBrieven.CentrumName).First();
                    Specialist specialist = centrum.GetSpecialisten().Where(x => x.BSN == itemBrieven.SpecialistBSN).First();

                    patiënt.RegisterBrief(new Brief(category, behandeling, itemBrieven.Details,
                        (BriefSoort)Enum.Parse(typeof(BriefSoort),itemBrieven.BriefSoort), (BriefStatus)Enum.Parse(typeof(BriefStatus),itemBrieven.BriefStatus),
                       itemBrieven.RegisterDate, itemBrieven.BehandelingDatum, new Time(itemBrieven.BegintTime),
                       specialist,centrum));

                }
               
                patiënten.Add(patiënt);
                
            }


            return patiënten;

        }

        public void SetPatienten(List<Patiënt> patienten)
        {

            List<DTO.Patiënt> dtoPatienten = new List<DTO.Patiënt>();
            List<DTO.Brief> dtoBrieven = new List<DTO.Brief>();
            foreach (var item in patienten)
            {

                dtoPatienten.Add(new DTO.Patiënt(item.BSN,item.FirstName,item.LastName,item.Birthday,item.EmailAddress,item.Address));
                foreach (var itemBrief in item.Brieven)
                {
                    dtoBrieven.Add(new DTO.Brief(item.BSN,itemBrief.Category.Name,itemBrief.Behandeling.Name,itemBrief.Details,
                        itemBrief.BriefSoort.ToString(),itemBrief.BriefStatus.ToString(),itemBrief.RegisterDate,
                        itemBrief.BehandelingDatum,itemBrief.BegintTime.GetTime(),itemBrief.Specialist.BSN,itemBrief.Centrum.Name));


                }


            }
            dataRepository.SetPatiënten(dtoPatienten);
            dataRepository.SetBrieven(dtoBrieven);



        }

        public List<Centrum> GetCentrums(List<Category> categories)
        {
            List<Centrum> centrumList = new List<Centrum>();
            List<Behandeling> behandelingen = new List<Behandeling>();
            foreach (var itemCategories in categories)
            {
                behandelingen.AddRange(itemCategories.Behandelingen);
            }

            List<DTO.BehandelingAgenda> dtoBehandelingAgendaList = dataRepository.GetBehandelingAgendas();
            List<DTO.Centrum> dtoCentra = dataRepository.GetCentrum();
            foreach (DTO.Centrum item in dtoCentra)
            {
                Centrum centrum = new Centrum(item.Name);
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
                  
                    BehandelingAgenda behandelingAgenda = new BehandelingAgenda(specialist, (Werkdag)Enum.Parse(typeof(Werkdag),itemBehandelingAgenda.Werkdag),
                        new Time(itemBehandelingAgenda.BeginTime),new Time(itemBehandelingAgenda.EndTime));

                    centrum.RegisterBehandelingAgenda(behandelingAgenda);
                } 

                
                centrumList.Add(centrum);
            }
            return centrumList;
        }

    }
}
