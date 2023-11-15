using MediatR;
using Stremou.Modules.Application.Handlers.User.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.User.Requests
{
    public class CheckUserExistsByEmailRequest : IRequest<CheckUserExistsByEmailResponse>
    {
        public Guid Id { get; private set; }
        public string? Email { get; set; }


        public CheckUserExistsByEmailRequest(string? cpf, string? email)
        {
            Id = Guid.NewGuid();
            Email = email;
        }

    }
}
