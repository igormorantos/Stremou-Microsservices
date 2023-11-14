using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Models
{
    public class User : Entity, IAggregateRoot
    {
        private readonly List<Video> _watchedVideos = new List<Video>();
        private readonly List<StreamingSession> _streamingSessions = new List<StreamingSession>();

        public User(Guid id, string name, string email, string password, ViewingPreferences viewingPreferences)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            ViewingPreferences = viewingPreferences;
            _watchedVideos = new List<Video>();
            _streamingSessions = new List<StreamingSession>();
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Name { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Password { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public ViewingPreferences ViewingPreferences { get; private set; }

        public IReadOnlyCollection<Video> WatchedVideos => _watchedVideos.AsReadOnly();
        public IReadOnlyCollection<StreamingSession> StreamingSessions => _streamingSessions.AsReadOnly();

        public void AddWatchedVideo(Video video)
        {
            _watchedVideos.Add(video);
        }

        public void AddStreamingSession(StreamingSession session)
        {
            _streamingSessions.Add(session);
        }
    }
}