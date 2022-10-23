using EAfspraak.Web.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Security.Claims;

namespace EAfspraak.Web.Pages
{
    [Authorize(Roles = "admin,huisarts,patient")]
    public class WelcomeModel : PageModel
    {
        public string UserId;

        private SecurityManager securityManager = new SecurityManager();

        public void OnGet()
        {
            UserId = User.FindFirst(ClaimTypes.Name).Value;
        }

      
    }
}
