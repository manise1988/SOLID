using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using EAfspraak.DataLayer.Contracts;

namespace EAspraak.Web.Pages.Admin
{
    public class BehandelingModel : PageModel
    {
        private readonly IBehandelingService behandelingService;

        public BehandelingModel(IBehandelingService behandelingService)
        {
            this.behandelingService = behandelingService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnAddPost()
        {
            return Page();// Json(new JsonResultOperation(true, "???? ???? ??? ?? ?????? ????? ??"));
            //if (!ModelState.IsValid)
            //{
            //    return Json(new JsonResultOperation(false, PublicConstantStrings.ModelStateErrorMessage)
            //    {
            //        Data = ModelState.GetModelStateErrors()
            //    });
            //}
        }
    }
}
