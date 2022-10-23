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

        public void OnGet()
        {
            UserId = User.FindFirst(ClaimTypes.Name).Value;
        }
    }
}
