using MediatR;
using Stremou.Modules.Application.Handlers.User.Responses;
using Stremou.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.User.Requests
{
    public class CheckUserExistsByCpfRequest : IRequest<CheckUserExistsByCpfResponse>
    {
        public Guid Id { get; private set; }
        public Cpf Cpf { get; set; }


        public CheckUserExistsByCpfRequest(Cpf cpf)
        {
            Id = Guid.NewGuid();
            Cpf = cpf;
        }

    }
}
