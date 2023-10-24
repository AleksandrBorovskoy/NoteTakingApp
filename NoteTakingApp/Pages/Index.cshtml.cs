using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteTakingApp.Entities;
using NoteTakingApp.Model;
using NoteTakingApp.ViewModels;

namespace NoteTakingApp.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly NoteDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public PaginatedList<Note> Notes { get; set; } = new PaginatedList<Note>();

        public IndexModel(NoteDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task OnGetAsync(int pageIndex = 1)
        {
            
            var currentUser = await _userManager.GetUserAsync(User);
            var notes = _dbContext.Notes.Where(n => n.UserId == currentUser.Id);

            if (notes.Any())
            {
                foreach (var note in notes)
                {
                    if(note.Description.Length > 100)
                    {
                        note.Description = note.Description[..97] + "...";
                    }
                    
                }
            }

            int pageSize = 12;

            Notes = await PaginatedList<Note>.CreateAsync(notes, pageSize, pageIndex);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int noteId)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(n => n.Id == noteId);
            if (note != null)
            {
                _dbContext.Notes.Remove(note);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}