using Stremou.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Stremou.Services.Authenticator.Models
{
    public class RegisterModel
    {
        [Required]
        public User Name { get; set; }

        [Required]
        [EmailAddress]
        public User Email { get; set; }

        [Required]
        public User Cpf { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public User Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não correspondem.")]
        public string ConfirmPassword { get; set; }
    }
}
