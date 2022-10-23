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
        private SecurityManager securityManager = new SecurityManager();

        public IndexModel()//IAfspraakService iAfspraakService)
        {
           // _IAfspraakService = iAfspraakService;
        }
        public void OnGet()
        {
            UserId = User.FindFirst(ClaimTypes.Name).Value;
            //List<Behandeling> list = _IBehandelingService.GetData(); 
            //HttpContext.Session.SetString("Username", "test1");

        }
        public IActionResult OnGetLogout()
        {
            securityManager.SignOut(HttpContext);
            return RedirectToPage("Login");
        }
     

    }
}
