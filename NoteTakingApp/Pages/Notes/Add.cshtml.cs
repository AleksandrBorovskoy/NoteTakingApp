using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteTakingApp.ViewModels;

namespace NoteTakingApp.Pages.Notes
{
    [Authorize]
    public class AddModel : PageModel
    {
        public Add Model { get; set; }
        public void OnGet()
        {
        }
    }
}
