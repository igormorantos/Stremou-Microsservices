using MediatR;
using Stremou.Modules.Application.Handlers.Bill.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillEntity = Stremou.Domain.Models.Bill;

namespace Stremou.Modules.Application.Handlers.Bill.Commands
{
    public class CreateBillCommand : IRequest<CreateBillResponse>
    {
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public Guid UserId { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTime BillDate { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public decimal TotalAmount { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public bool PaymentStatus { get; private set; }



        public BillEntity GetEntity()
        {
            return new BillEntity(
                this.UserId,
                this.BillDate,
                this.TotalAmount,
                this.PaymentStatus
                );
        }
    }
}
