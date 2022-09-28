using EAfspraak.DataLayer.Contracts;
using EAfspraak.DataLayer.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EAspraak.Web.Pages
{
    public class IndexModel : PageModel
    {
        private IBehandelingService _IBehandelingService;

        public IndexModel(IBehandelingService iBehandelingService)
        {
            _IBehandelingService = iBehandelingService;
        }
        public void OnGet()
        {
            List<Behandeling> list = _IBehandelingService.GetData(); 
            
        }
    }
}
