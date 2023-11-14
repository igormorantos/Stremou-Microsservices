using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Models
{
    public class StreamingSession : Entity, IAggregateRoot
    {
        public StreamingSession(Guid id, Guid userId, Guid videoId, DateTime startTime, DateTime endTime)
        {
            Id = id;
            UserId = userId;
            VideoId = videoId;
            StartTime = startTime;
            EndTime = endTime;
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        public Guid UserId { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public Guid VideoId { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTime StartTime { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTime EndTime { get; private set; }
    }
}
