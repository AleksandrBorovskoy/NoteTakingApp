using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NoteTakingApp.Model
{
    public class NoteDbContext : IdentityDbContext
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options) { }
    }
}
