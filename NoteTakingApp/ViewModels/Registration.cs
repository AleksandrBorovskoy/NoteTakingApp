using System.ComponentModel.DataAnnotations;

namespace NoteTakingApp.ViewModels
{
    public class Registration
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password confirmation failed")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
