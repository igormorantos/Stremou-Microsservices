using NetDevPack.Domain;
using Stremou.Modules.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Title { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Description { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public Category? Category { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public TimeSpan? Duration { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? VideoUrl { get; private set; }
    }
}
