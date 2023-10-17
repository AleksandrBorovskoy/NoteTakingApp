using Microsoft.AspNetCore.Identity;

namespace NoteTakingApp.Entities
{
    public class User : IdentityUser
    {
        public IList<Note>? Notes { get; set; } = default;
    }
}
