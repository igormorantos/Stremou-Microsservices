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

        public Guid UserId { get; private set; }

        public DateTime BillDate { get; private set; }

        public decimal TotalAmount { get; private set; }

        public bool PaymentStatus { get; private set; }
    }
}
