using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using EAfspraak.DataLayer.Services;

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
