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
    public class BillViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [DisplayName("ID do Usuário")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public Guid UserId { get; private set; }

        [DisplayName("Data da Fatura")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public DateTime BillDate { get; private set; }

        [DisplayName("Valor Total")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public decimal TotalAmount { get; private set; }

        [DisplayName("Status do Pagamento")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public string PaymentStatus { get; private set; }
    }
}
