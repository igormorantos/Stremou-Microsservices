using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Models
{
    public class Recommendation : Entity, IAggregateRoot
    {
        public Recommendation(Guid id, Guid userId, Guid videoId, DateTime recommendationTime)
        {
            Id = id;
            UserId = userId;
            VideoId = videoId;
            RecommendationTime = recommendationTime;
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        public Guid UserId { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public Guid VideoId { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTime RecommendationTime { get; private set; }
    }
}
