using NetDevPack.Domain;
using Stremou.Modules.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Stremou.Domain.Models
{
    public class Video : Entity, IAggregateRoot
    {
        public Video(Guid id, string title, string description, Category category, TimeSpan duration, string videoUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = category;
            Duration = duration;
            VideoUrl = videoUrl;
        }

        public string? Title { get; private set; }

        public string? Description { get; private set; }

        public Category? Category { get; private set; }

        public TimeSpan? Duration { get; private set; }

        public string? VideoUrl { get; private set; }
    }
}
