using NetDevPack.Domain;
using Stremou.Modules.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Models
{
    public class VideoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public string? Title { get; private set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public string? Description { get; private set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public Category Category { get; private set; }

        [DisplayName("Duração do Video")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public TimeSpan? Duration { get; private set; }

        [DisplayName("URL do Vídeo")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public string? VideoUrl { get; private set; }
    }
}
