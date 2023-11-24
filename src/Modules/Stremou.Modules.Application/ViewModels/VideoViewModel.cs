using Stremou.Modules.Domain.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stremou.Domain.Models
{
    public class VideoViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "O campo Titulo deve ser preenchido.")]
        public string? Title { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo Descrição deve ser preenchido.")]
        public string? Description { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O campo Categoria deve ser preenchido.")]
        public Category Category { get; set; }

        [DisplayName("Duração do Video")]
        [Required(ErrorMessage = "O campo Duração deve ser preenchido.")]
        public TimeSpan? Duration { get; set; }

        [DisplayName("URL do Vídeo")]
        [Required(ErrorMessage = "O campo Url deve ser preenchido.")]
        public string? VideoUrl { get; set; }
    }
}
