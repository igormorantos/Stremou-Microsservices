using Stremou.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Stremou.Services.Authenticator.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public User Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public User Password { get; set; }
    }
}
