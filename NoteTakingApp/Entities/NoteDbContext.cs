using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteTakingApp.Entities;

namespace NoteTakingApp.Model
{
    public class NoteDbContext : IdentityDbContext<User>
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
    }
}
