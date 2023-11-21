using NetDevPack.Domain;
using Stremou.Modules.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;


namespace Stremou.Domain.Models
{
    public class User : Entity, IAggregateRoot
    {

        public User(string name, string email, string password, Cpf cpf)
        {
            Name = name;
            Email = email;
            Password = password;
            Cpf = cpf;
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Name { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Password { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public Cpf Cpf { get; private set; }

    }
}