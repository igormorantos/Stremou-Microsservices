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
       
        public Guid Id { get; private set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public Category Category { get; set; }

        public TimeSpan Duration { get; set; }

        public string? VideoUrl { get; set; }

        public CreateVideoCommand()
        {
            Id = Guid.NewGuid();
        }

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
