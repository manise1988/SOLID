using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            //DataContext.FullCategory();
            //DataContext.FullCentrum();
            //DataContext.FullBehandelingAgenda();
            //foreach (var itemCategory in DataContext.Categories)
            //{
            //    Category category = new Category(itemCategory.Name);
            //    foreach (var itemBehandeling in itemCategory.Behandelingen)
            //    {
            //        Behandeling behandeling = new Behandeling(itemBehandeling.Name, itemBehandeling.DurationTime);
            //        category.AddBehandeling(behandeling);
            //    }
            //    Categories.Add(category);
            //}

            //foreach (var itemCentrum in DataContext.Centrums)
            //{
            //    Centrum centrum = new Centrum(itemCentrum.Name);
            //    foreach (var itemSpecialist in itemCentrum.Specialists)
            //    {
            //        Category category = new Category(itemSpecialist.Category.Name);
            //        foreach (var itemBehandeling in itemSpecialist.Category.Behandelingen)
            //        {
            //            Behandeling behandeling = new Behandeling(itemBehandeling.Name, itemBehandeling.DurationTime);
            //            category.AddBehandeling(behandeling);
            //        }

            //        Specialist specialist = new Specialist(itemSpecialist.BSN, itemSpecialist.FirstName,itemSpecialist.LastName,category);
            //        centrum.Specialists.Add(specialist);
            //    }
            //    foreach (var itemBehandeling in itemCentrum.GetBehandelings())
            //    {
            //        Behandeling behandeling = new Behandeling(itemBehandeling.Name, itemBehandeling.DurationTime);
            //        centrum.AddBehandelingToCentrum(behandeling);

            //    }
            //    foreach (var itemBehandelingAgenda in itemCentrum.GetBehandelingAgendas()) 
            //    {
            //        Category category = new Category(itemBehandelingAgenda.Sepecialist.Category.Name);
            //        foreach (var itemBehandeling in itemBehandelingAgenda.Sepecialist.Category.Behandelingen)
            //        {
            //            Behandeling behandeling = new Behandeling(itemBehandeling.Name, itemBehandeling.DurationTime);
            //            category.AddBehandeling(behandeling);
            //        }
            //        Specialist specialist = new Specialist(itemBehandelingAgenda.Sepecialist.BSN, itemBehandelingAgenda.Sepecialist.FirstName,
            //            itemBehandelingAgenda.Sepecialist.LastName, category);

            //        Werkdag werkdag = (Werkdag)itemBehandelingAgenda.werkdag;
            //        BehandelingAgenda behandelingAgenda = new BehandelingAgenda(specialist, werkdag,
            //            itemBehandelingAgenda.BegintTime, itemBehandelingAgenda.EindTime);
            //        centrum.RegisterBehandelingAgenda(behandelingAgenda);
            //    }
            //    Centrums.Add(centrum);

        //}
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
        public List<Time> CalculateWachtLijst(string centrumName, long spesialistBSN , string behandelingName,DateTime selectedDay)
        {
            return Centrums.Where(x=> x.Name== centrumName).First().CalculateWachtLijst(spesialistBSN,behandelingName, selectedDay);
        }

    }
}
