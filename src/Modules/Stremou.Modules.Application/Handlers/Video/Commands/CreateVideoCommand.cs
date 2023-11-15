using MediatR;
using Stremou.Domain.Models;
using Stremou.Modules.Application.Handlers.Video.Responses;
using Stremou.Modules.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using VideoEntity = Stremou.Domain.Models.Video;

namespace Stremou.Modules.Application.Handlers.Video.Commands
{
    public class CreateVideoCommand : IRequest<CreateVideoResponse>
    {
       
        public Guid Id { get; set; }
        public string? Title { get; private set; }

        public string? Description { get; private set; }

        public Category Category { get; private set; }

        public TimeSpan Duration { get; private set; }

        public string? VideoUrl { get; private set; }

        public VideoEntity GetEntity()
        {
            return new VideoEntity(
                this.Id,
                this.Title,
                this.Description,
                this.Category,
                this.Duration,
                this.VideoUrl
                );
        }
    }
}
