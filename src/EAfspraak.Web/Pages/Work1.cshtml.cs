using EAfspraak.Web.ViewModels;
using EAfspraak.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Security.Claims;
using EAfspraak.Domain;

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
        public List<KliniekTijdenViewModel> KliniekAgendas { get; set; }

        public List<string> Steden;
        [BindProperty]
        public string Stad { get; set; }
        public List<string> Datums;
        [BindProperty(SupportsGet = true)]
        public string Datum { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Kliniek { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BeschikbareDatum { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Momment { get; set; }

        public List<KliniekTijdenViewModel> Agendas { get; set; }

        private readonly AfspraakService AfspraakService;
        public Work1Model()
        {
            AfspraakService = new AfspraakService();
            
                      
            Categories = AfspraakService.GetCategories();
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
                object werkdag = null;
                object date = null;
                if(Momment!=null)
                    werkdag = (Werkdag) Enum.Parse(typeof(Werkdag),Momment,true);
                if (Datum != null)
                    date = DateTime.Parse(Datum);
                 
                    Klieniken = AfspraakService.GetKliniekenMetVrijeTijden(behandelingName, date, werkdag);
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

        private void mogelijkeMommenten()
        {
            List<KliniekViewModel> selectedKlieniken = new List<KliniekViewModel>();
            getKlinieken();

            
            if (BeschikbareDatum == null)
                BeschikbareDatum = "";
            if (Kliniek == null)
                Kliniek = "";
            if (Stad == null)
                Stad = "";
            selectedKlieniken = Klieniken;
            if (BeschikbareDatum != "")
                foreach (var item in Klieniken)
                {
                    var agendas = item.Agendas.Where(x => x.Date != BeschikbareDatum).ToList();

                    foreach (var agenda in agendas)
                    {
                        item.Agendas.Remove(agenda);
                    }

                }


            if (Kliniek != "")
                selectedKlieniken = selectedKlieniken.Where(x => x.Name == Kliniek).ToList();
            if (Stad != "")
                selectedKlieniken = selectedKlieniken.Where(x => x.locatie == Stad).ToList();

            KliniekAgendas = new List<KliniekTijdenViewModel>();
            foreach (var item in selectedKlieniken)
            {

                foreach (var itemAgenda in item.Agendas)
                {
                    KliniekTijdenViewModel kliniekAgenda = new KliniekTijdenViewModel(
                    item.Name,
                    item.locatie,itemAgenda.SpecialistBSN,
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
            string patientBSN = User.FindFirst(ClaimTypes.Name).Value;
            AfspraakService.MaakAfspraak( behandelingName, kliniekName, long.Parse(patientBSN),
               long.Parse(specialistBSN), date, time);
            mogelijkeMommenten();
            return Page();
        }



  
    }
}
