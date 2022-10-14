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
    public class AfspraakService : IAfspraakService
    {
        public List<Category> Categories { get; set; }
        public List<Centrum> Centrums { get; set; }
        public List<Patiënt> Patiënts { get; set; }

        public AfspraakService()
        {
            Categories = new List<Category>();
            Centrums = new List<Centrum>();
            Patiënts = new List<Patiënt>();

            DataRepotisory dataRepository = new DataRepotisory();
            DTO.Category[] dtoCategories = dataRepository.GetCategories();

            DTO.Centrum[] dtoCentrums = dataRepository.GetCentrum();

            foreach (DTO.Category item in dtoCategories)
            {
                Category category = new Category(item.Name);
                foreach (DTO.Behandeling itemBehandeling in item.Behandelingen)
                {
                    Behandeling behandeling = new Behandeling(itemBehandeling.Name,
                        new Time(itemBehandeling.DurationTime), itemBehandeling.IsVerwijsbriefNodig);
                    category.Behandelingen.Add(behandeling);

                }
                

            }

            foreach (DTO.Centrum item in dtoCentrums)
            {
                Centrum centrum = new Centrum(item.Name);
                foreach (var itemSpecialist in item.Specialisten)
                {
                    Category category = new Category(itemSpecialist.Category.Name);
                    Specialist specialist = new Specialist(itemSpecialist.BSN,
                        itemSpecialist.FirstName, itemSpecialist.LastName, category
                        );
                    centrum.AddSpesialistToCentrum(specialist);
                }
                foreach (var itemBehandeling in item.Behandelingen)
                {
                    Behandeling behandeling = new Behandeling(itemBehandeling.Name,
                        new Time(itemBehandeling.DurationTime), itemBehandeling.IsVerwijsbriefNodig);
                    centrum.AddBehandelingToCentrum(behandeling);
                }
                foreach (var itemBehandelingAgena in item.BehandelingAgendas)
                {
                    Category category = new Category(itemBehandelingAgena.Specialist.Category.Name);
                    Specialist specialist = new Specialist(itemBehandelingAgena.Specialist.BSN,
                        itemBehandelingAgena.Specialist.FirstName, itemBehandelingAgena.Specialist.LastName, category
                        );

                    BehandelingAgenda behandelingAgenda = new BehandelingAgenda(specialist,
                       (Werkdag)Enum.Parse(typeof(Werkdag), itemBehandelingAgena.Werkdag),
                       new Time(itemBehandelingAgena.BeginTime), new Time(itemBehandelingAgena.EndTime));
                    centrum.RegisterBehandelingAgenda(behandelingAgenda);
                }
                if(item.Patiënten!=null)
                foreach (var itemPatient in item.Patiënten)
                {
                    Patiënt patient = new Patiënt(itemPatient.BSN, itemPatient.FirstName,
                        itemPatient.LastName, (DateTime)itemPatient.Birthday, itemPatient.EmailAddress,
                        itemPatient.Address);
                    foreach (var itemBrief in itemPatient.Brieven)
                    {
                        Category category = new Category(itemBrief.Category.Name);
                        Behandeling behandeling = new Behandeling(itemBrief.Behandeling.Name,
                           new Time(itemBrief.Behandeling.DurationTime), itemBrief.Behandeling.IsVerwijsbriefNodig);

                        Category categorySpecialist = new Category(itemBrief.Specialist.Category.Name);
                        Specialist specialist = new Specialist(itemBrief.Specialist.BSN,
                            itemBrief.Specialist.FirstName, itemBrief.Specialist.LastName, category
                            );
                        

                        Brief brief = new Brief(category, behandeling, itemBrief.Details,
                        (BriefSoort)Enum.Parse(typeof(BriefSoort), itemBrief.BriefSoort),
                        (BriefStatus)Enum.Parse(typeof(BriefStatus), itemBrief.BriefStatus),
                        itemBrief.RegisterDate, itemBrief.BehandelingDatum, new Time(itemBrief.BegintTime),
                            specialist, centrum);


                    }
                }

                Centrums.Add(centrum);
            }
        
    }
        public Brief MaakAfspraak()
        {
            
            throw new NotImplementedException();
        }

        public void RegisterBrief(Patiënt patiënt, Brief brief)
        {
            if (Patiënts.Where(p => p.BSN != patiënt.BSN).Any())
            {
                patiënt.RegisterBrief(brief);
                Patiënts.Add(patiënt);
            }
            else
            {
                Patiënts.Where(p => p.BSN != patiënt.BSN)
                    .First().RegisterBrief(brief);

            }
        }
        public  List<Centrum> GetCentrums(Behandeling behandeling)
        {
            return Centrums.Where(x=> x.HaveToBehandeling(behandeling.Name)==true).ToList();
        }
        public List<Time> CalculateWachtLijst(string centrumName, long spesialistBSN,string categoryName, string behandelingName,DateTime selectedDay)
        {
            return Centrums.Where(x=> x.Name== centrumName).First().CalculateVrijeTijd(spesialistBSN,categoryName,behandelingName, selectedDay);
        }

    }
}
