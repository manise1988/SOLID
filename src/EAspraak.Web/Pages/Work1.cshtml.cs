using EAfspraak.Services.Domain;
using EAfspraak.Services.Services.Interfases;
using EAfspraak.Services.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Security.Claims;

namespace EAfspraak.Web.Pages
{
    [Authorize(Roles = "admin")]
    public class Work1Model : PageModel
    {
        public string UserId;
        public List<Category> Categories;
        [BindProperty]
        public string BehandelingName { get; set; }

        public List<KliniekViewModel> Klieniken ;
        public List<string> Steden;
        [BindProperty]
        public string Stad { get; set; }
        public List<string> Datums;
        [BindProperty]
        public string Datum { get; set; }
        [BindProperty]
        public string KliniekName { get; set; }
        [BindProperty]
        public string Momment { get; set; }

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
        public IActionResult OnPostZoek()
        {

            Klieniken = iAfspraakService.GetCentrums(BehandelingName);
            Steden = new List<string>();
            Datums= new List<string>();
            foreach (var item in Klieniken.GroupBy(x => x.locatie).ToList())
                Steden.Add(item.Key.ToString());
            foreach (var item in Klieniken)
            {
                string datum = "";
                foreach (var itemDatum in item.Agendas.GroupBy(x => x.Date).ToList())
                {
                    if(!Datums.Where(x=> x == itemDatum.Key.ToString()).Any())
                    Datums.Add(itemDatum.Key.ToString());
                }
                
            }

            return Page();
        }
    }
}
