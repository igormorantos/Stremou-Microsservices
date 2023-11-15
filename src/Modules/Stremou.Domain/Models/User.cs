using NetDevPack.Domain;
using Stremou.Modules.Domain.ValueObjects;
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

        public User(Guid id, string name, string email, string password, Cpf recommendation)
        {
            Name = name;
            Email = email;
            Password = password;
            Recommendation = recommendation;
            _watchedVideos = new List<Video>();
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
        public Cpf Cpf { get; private set; }

        public IReadOnlyCollection<Video> WatchedVideos => _watchedVideos.AsReadOnly();

        public void AddWatchedVideo(Video video)
        {
            _watchedVideos.Add(video);
        }
    }
}