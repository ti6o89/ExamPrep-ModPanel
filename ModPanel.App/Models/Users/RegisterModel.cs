using ModPanel.App.Data.Models;
using ModPanel.App.Infrastructure.Users;
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
