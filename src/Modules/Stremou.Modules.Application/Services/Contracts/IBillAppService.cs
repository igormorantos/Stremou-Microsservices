using Stremou.Domain.Models;
using Stremou.Modules.Application.Handlers.Bill.Commands;
using Stremou.Modules.Application.Handlers.User.Commands;
using Stremou.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Contracts
{
    public interface IBillAppService
    {
        Task<BillViewModel> GetByUserId(Guid id);

        Task Save(CreateBillCommand commandCreate);
    }
}
