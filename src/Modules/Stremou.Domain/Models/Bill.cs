using NetDevPack.Domain;
using System.ComponentModel.DataAnnotations;

namespace Stremou.Domain.Models
{
    public class Bill : Entity, IAggregateRoot
    {
        public Bill(Guid userId, DateTime billDate, decimal totalAmount, bool paymentStatus)
        {
            UserId = userId;
            BillDate = billDate;
            TotalAmount = totalAmount;
            PaymentStatus = paymentStatus;
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        public Guid UserId { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTime BillDate { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public decimal TotalAmount { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public bool PaymentStatus { get; private set; }
    }
}
