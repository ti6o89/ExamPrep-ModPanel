using ModPanel.App.Infrastructure.Validation.Users;
using System.ComponentModel.DataAnnotations;

namespace ModPanel.App.Models.Users
{
    public class RegisterModel
    {
        [Required]
        [Email]
        public string Email { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        public int Position { get; set; }
    }
}
