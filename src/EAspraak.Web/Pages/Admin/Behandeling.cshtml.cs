using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using EAfspraak.Services.Interfases;

namespace EAspraak.Web.Pages.Admin
{
    public class BehandelingModel : PageModel
    {
        private readonly IAfspraakService AfspraakService;

        public BehandelingModel(IAfspraakService afspraakService)
        {
            this.AfspraakService = afspraakService;
        }
        public void OnGet()
        {
        }
       
      
    }
}
