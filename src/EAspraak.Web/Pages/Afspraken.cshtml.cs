using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace EAfspraak.Web.Pages
{
    public class AfsprakenModel : PageModel
    {
        public string UserId;
        public IActionResult OnGet()
        {
            UserId = User.FindFirst(ClaimTypes.Name).Value;

            return Page();
        }
    }
}
