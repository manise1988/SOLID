using EAfspraak.Services.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EAspraak.Web.Pages
{
    public class IndexModel : PageModel
    {
        private IAfspraakService _IAfspraakService;

        public IndexModel(IAfspraakService iAfspraakService)
        {
            _IAfspraakService = iAfspraakService;
        }
        public void OnGet()
        {
            //List<Behandeling> list = _IBehandelingService.GetData(); 
            
        }
    }
}
