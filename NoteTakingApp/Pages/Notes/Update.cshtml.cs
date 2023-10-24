using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteTakingApp.Model;
using NoteTakingApp.ViewModels;

namespace NoteTakingApp.Pages.Notes
{
    public class UpdateModel : PageModel
    {
        private readonly NoteDbContext _dbContext;
        [BindProperty]
        public Add Model { get; set; }
        public UpdateModel(NoteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task OnGet(int noteId)
        {
            Model = new Add
            {
                NoteId = noteId
            };

            var currentNote = await _dbContext.Notes.FirstOrDefaultAsync(n => n.Id == noteId);

            if(currentNote != null)
            {
                Model.Title = currentNote.Title;
                Model.Description = currentNote.Description;
            }
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentNote = await _dbContext.Notes.FirstOrDefaultAsync(n => n.Id == Model.NoteId);

            if(currentNote != null)
            {
                currentNote.Title = Model.Title;
                currentNote.Description = Model.Description;
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
