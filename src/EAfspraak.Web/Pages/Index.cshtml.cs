//using EAfspraak.Services.Interfaces;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Security.Claims;
using EAfspraak.Web.Services;

namespace EAfspraak.Web.Pages
{
    [Authorize(Roles = "admin,patient")]
    public class IndexModel : PageModel
    {
       // private AfspraakService afspraakService;
        public string UserId;
        public string Role="patient";
        private SecurityService securityManager;

        public IndexModel()
        {
          this.securityManager = new SecurityService();

        }
        public void OnGet()
        {
            UserId = User.FindFirst(ClaimTypes.Name).Value;
            Role = User.FindFirst(ClaimTypes.Name).Subject.Claims.ElementAt(3).Value;
         

        }
        public IActionResult OnGetLogout()
        {
            securityManager.SignOut(HttpContext);
            return RedirectToPage("Login");
        }
     

    }
}
