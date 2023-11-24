using NetDevPack.Domain;
using Stremou.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Models
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("Nome do Usuario")]
        [Required(ErrorMessage = "O campo Name deve ser preenchido.")]
        public string? Name { get; set; }

        [DisplayName("Email do Usuario")]
        [Required(ErrorMessage = "O campo Email deve ser preenchido.")]
        [EmailAddress]
        public string? Email { get; set; }

        [DisplayName("Senha do Usuario")]
        [Required(ErrorMessage = "O campo Password deve ser preenchido.")]
        [PasswordPropertyText]
        public string? Password { get; set; }

        [DisplayName("Cpf do Usuario")]
        [Required(ErrorMessage = "O campo Cpf deve ser preenchido.")]
        public Cpf Cpf { get; set; }

    }
}