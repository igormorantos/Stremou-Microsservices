using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Models
{
    public class Bill : Entity, IAggregateRoot
    {
        public Bill(Guid id, Guid userId, DateTime billDate, decimal totalAmount, string paymentStatus)
        {
            Id = id;
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
        public string PaymentStatus { get; private set; }
    }
}
