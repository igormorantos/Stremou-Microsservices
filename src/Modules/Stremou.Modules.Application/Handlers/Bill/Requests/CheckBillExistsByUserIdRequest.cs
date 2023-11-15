using MediatR;
using Stremou.Modules.Application.Handlers.Bill.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.Bill.Requests
{
    public class CheckBillExistsByUserIdRequest : IRequest<CheckBillExistsByUserIdResponse>
    {
        
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public CheckBillExistsByUserIdRequest(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
        }

    }
}
