using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Models
{
    public class StreamingSessionViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("ID do Usuário")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public Guid UserId { get; private set; }

        [DisplayName("ID do Vídeo")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public Guid VideoId { get; private set; }

        [DisplayName("Hora de Início")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public DateTime StartTime { get; private set; }

        [DisplayName("Hora de Término")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public DateTime EndTime { get; private set; }
    }
}
