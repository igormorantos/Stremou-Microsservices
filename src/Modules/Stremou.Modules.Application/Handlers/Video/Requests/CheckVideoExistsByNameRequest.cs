using MediatR;
using Stremou.Modules.Application.Handlers.Video.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.Video.Requests
{
    public class CheckVideoExistsByNameRequest : IRequest<CheckVideoExistsByNameResponse>
    {
        public Guid Id { get; private set; }

        public string? Name { get; private set; }

        public CheckVideoExistsByNameRequest(string? name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
