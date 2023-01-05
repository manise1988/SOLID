using EAfspraak.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EAfspraak.Web.Pages
{
    public class SignupModel : PageModel
    {
        public string message;

        [BindProperty(SupportsGet = true)]
        [Required]
        public string FirstName { get; set; }
        [BindProperty(SupportsGet = true)]
        [Required]
        public string LastName { get; set; }
        [Required]
        [BindProperty(SupportsGet = true)]
        public DateTime BirthsDay { get; set; }
        [BindProperty(SupportsGet = true)]
        [Required]
        [Range(100000000,999999999)]
        public long BSNnummer { get; set; }
        private AfspraakService afspraakService;

        public SignupModel()
        {
            this.afspraakService = new AfspraakService();
         
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostAddPatient()
        {
            if (ModelState.IsValid)
            {
                if (afspraakService.AddPatient(BSNnummer, FirstName, LastName, BirthsDay))
                {
                    return RedirectToPage("Login");
                }
                else
                {
                    message = "Dit patient staat in de database. Log maar in.";
                }
            }
            else
            {
                message = "Vull maar de juiste waarde.";
            }
            
            return Page();
        }
    }
}
