using MediatR;
using Stremou.Modules.Application.Handlers.Video.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.Video.Requests
{
    public class CheckVideoExistsByTitleRequest : IRequest<CheckVideoExistsByTitleResponse>
    {
        public Guid Id { get; private set; }

        public string? Title { get; set; }

        public CheckVideoExistsByTitleRequest(string? title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }
    }
}
