using EAfspraak.Services.Interfases;
using EAfspraak.Services.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Security.Claims;

namespace EAfspraak.Web.Pages
{
    [Authorize(Roles = "patient")]
    public class Work1Model : PageModel
    {
        public string UserId;
        public List<CategoryViewModel> Categories;
        [BindProperty(SupportsGet = true)]
        public string BehandelingName { get; set; }


        [BindProperty(SupportsGet =true)]
        public List<KliniekViewModel> Klieniken { get; set; }

      
        [BindProperty(SupportsGet = true)]
        public List<KliniekAgendaViewModel> KliniekAgendas { get; set; }

        public List<string> Steden;
        [BindProperty]
        public string Stad { get; set; }
        public List<string> Datums;
        [BindProperty(SupportsGet = true)]
        public string Datum { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Kliniek { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Momment { get; set; }

        public List<KliniekAgendaViewModel> Agendas { get; set; }

        private readonly IAfspraakService iAfspraakService;

        public Work1Model(IAfspraakService iAfspraakService)
        {
            this.iAfspraakService = iAfspraakService;
            
            Categories = iAfspraakService.GetCategories();
        }
        public IActionResult OnGet()
        {
            UserId = User.FindFirst(ClaimTypes.Name).Value;
    
            return Page();
        }
        private void getKlinieken()
        {
            UserId = User.FindFirst(ClaimTypes.Name).Value;
            if (BehandelingName != null)
            {
                string categryName = BehandelingName.Split('+')[0];
                string behandelingName = BehandelingName.Split('+')[1];
                Klieniken = iAfspraakService.GetCentrumsMetVrijeTijden(behandelingName);
                Steden = new List<string>();
                Datums = new List<string>();
                foreach (var item in Klieniken.GroupBy(x => x.locatie).ToList())
                    Steden.Add(item.Key.ToString());
                foreach (var item in Klieniken)
                {
                    string datum = "";
                    foreach (var itemDatum in item.Agendas.GroupBy(x => x.Date).ToList())
                    {
                        if (!Datums.Where(x => x == itemDatum.Key.ToString()).Any())
                            Datums.Add(itemDatum.Key.ToString());
                    }

                }
            }
        }
        public IActionResult OnGetZoek()
        {
            getKlinieken();
           

            return Page();
        }

        private void mogelijkeMommenten()
        {
            List<KliniekViewModel> selectedKlieniken = new List<KliniekViewModel>();
            getKlinieken();

            if (Datum == null)
                Datum = "";
            if (Kliniek == null)
                Kliniek = "";
            if (Stad == null)
                Stad = "";
            if (Momment == null)
                Momment = "";
            selectedKlieniken = Klieniken;
            if (Datum != "")
                foreach (var item in Klieniken)
                {
                    var agendas = item.Agendas.Where(x => x.Date != Datum).ToList();

                    foreach (var agenda in agendas)
                    {
                        item.Agendas.Remove(agenda);
                    }

                }


            if (Kliniek != "")
                selectedKlieniken = selectedKlieniken.Where(x => x.Name == Kliniek).ToList();
            if (Stad != "")
                selectedKlieniken = selectedKlieniken.Where(x => x.locatie == Stad).ToList();

            KliniekAgendas = new List<KliniekAgendaViewModel>();
            foreach (var item in selectedKlieniken)
            {

                foreach (var itemAgenda in item.Agendas)
                {
                    KliniekAgendaViewModel kliniekAgenda = new KliniekAgendaViewModel(
                    item.Name,
                    item.locatie,itemAgenda.SpecialistName,itemAgenda.SpecialistBSN,
                    itemAgenda.Date,
                    itemAgenda.AfspraakTime);
                    KliniekAgendas.Add(kliniekAgenda);
                }

            }
        }
        public IActionResult OnPostZoekMogelijkeMomenten()
        {
            mogelijkeMommenten();

            return Page();  
        }
        public IActionResult OnPostAfspraakBevestigen(string kliniekName,string specialistBSN,string date,string time)
        {
            string categryName = BehandelingName.Split('+')[0];
            string behandelingName = BehandelingName.Split('+')[1];
            string patiëntBSN = User.FindFirst(ClaimTypes.Name).Value;
            iAfspraakService.MaakAfspraak(categryName, behandelingName, kliniekName, long.Parse(patiëntBSN),
                long.Parse(specialistBSN), date, time);
            mogelijkeMommenten();
            return Page();
        }
    }
}
