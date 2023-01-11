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
    public class Work2Model : PageModel
    {
        
        public string UserId="";
        [BindProperty(SupportsGet = true)]
        public List<KliniekTijdenViewModel> AfspraakList { get; set; }
        AfspraakService afspraakService;
        public Work2Model()
        {
            afspraakService = new AfspraakService();
            AfspraakList = new List<KliniekTijdenViewModel>();
        }
        public IActionResult OnGet()
        {
            UserId = User.FindFirst(ClaimTypes.Name).Value;

            List<Afspraak> list = afspraakService.GetAfsprakenByPatientBSN(long.Parse(UserId));

            AfspraakList.Clear();
            if(list!= null)
                if(list.Count>0)
                    foreach (var item in list)
                    {
                        KliniekTijdenViewModel currentData = new KliniekTijdenViewModel(item.Kliniek.Name
                            , item.Behandeling.Name,0, item.Datum.ToShortDateString(), item.BehandelingTime.GetTime());
                        AfspraakList.Add(currentData);
                    }
            
            return Page();
        }
    }
}
