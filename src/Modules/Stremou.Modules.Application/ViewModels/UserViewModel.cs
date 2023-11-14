﻿using NetDevPack.Domain;
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
        public Guid Id { get; set; }

        [DisplayName("Nome do Usuario")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public string? Name { get; private set; }

        [DisplayName("Email do Usuario")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public string? Email { get; private set; }

        [DisplayName("Senha do Usuario")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public string? Password { get; private set; }

        [DisplayName("Preferências de Visualização do Usuario")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public ViewingPreferences ViewingPreferences { get; private set; }

    }
}