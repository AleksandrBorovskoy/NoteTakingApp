using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteTakingApp.ViewModels;

namespace NoteTakingApp.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public Registration Model { get; set; } 
        public void OnGet()
        {
        }
    }
}
