using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteTakingApp.Entities;
using NoteTakingApp.Model;

namespace NoteTakingApp.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly NoteDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public List<Note> Notes { get; set; } = new List<Note>();

        public IndexModel(NoteDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var notes = await _dbContext.Notes.Where(n => n.UserId == currentUser.Id).ToListAsync();

            if (notes.Count > 0)
            {
                foreach (var note in notes)
                {
                    if(note.Description.Length > 100)
                    {
                        note.Description = note.Description[..97] + "...";
                    }
                    
                }
            }

            Notes = notes;
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