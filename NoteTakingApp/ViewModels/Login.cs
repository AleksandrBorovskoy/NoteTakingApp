using System.ComponentModel.DataAnnotations;

namespace NoteTakingApp.ViewModels
{
    public class Login
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}
