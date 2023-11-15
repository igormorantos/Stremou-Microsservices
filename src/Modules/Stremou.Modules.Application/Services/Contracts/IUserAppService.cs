using Stremou.Domain.Models;
using Stremou.Modules.Application.Handlers.User.Commands;
using Stremou.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Contracts
{
    public interface IUserAppService
    {
        Task<UserViewModel> GetByEmail(string email);

        Task<UserViewModel> GetByCPF(Cpf cpf);

        Task Save(CreateUserCommand commandCreate);
    }
}
