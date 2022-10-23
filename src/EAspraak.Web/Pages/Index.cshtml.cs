using EAfspraak.Services.Services;
using EAfspraak.Web.Models;
using EAfspraak.Web.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Security.Claims;

namespace EAfspraak.Web.Pages
{
    [Authorize(Roles = "admin,huisarts,patient")]
    public class IndexModel : PageModel
    {
        //private IAfspraakService _IAfspraakService;
        public string UserId;
        public string Role="patient";
        private SecurityManager securityManager = new SecurityManager();

        public IndexModel()//IAfspraakService iAfspraakService)
        {
           // _IAfspraakService = iAfspraakService;
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
