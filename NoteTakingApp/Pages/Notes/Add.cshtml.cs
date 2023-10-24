using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteTakingApp.Entities;
using NoteTakingApp.Model;
using NoteTakingApp.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace NoteTakingApp.Pages.Notes
{
    [Authorize]
    public class AddModel : PageModel
    {
        private readonly NoteDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public Add Model { get; set; }

        public AddModel(NoteDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostSaveAsync() 
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var currentUser = await _userManager.GetUserAsync(User);

            var note = new Note
            {
                Title = Model.Title,
                Description = Model.Description,
                UserId = currentUser.Id,
                User = currentUser
            };

            await _dbContext.Notes.AddAsync(note);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDeleteAsync()
        {
            return RedirectToPage("/Index");
        }
    }
}
