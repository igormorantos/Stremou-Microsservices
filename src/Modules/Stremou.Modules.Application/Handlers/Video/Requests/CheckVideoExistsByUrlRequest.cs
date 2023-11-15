using MediatR;
using Stremou.Modules.Application.Handlers.Video.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.Video.Requests
{
    public class CheckVideoExistsByUrlRequest : IRequest<CheckVideoExistsByUrlResponse>
    {

        public Guid Id { get; set; }

        public string? VideoUrl { get; private set; }

        public CheckVideoExistsByUrlRequest(Guid id, string? videoUrl)
        {
            Id = Guid.NewGuid();
            VideoUrl = videoUrl;
        }

    }
}
