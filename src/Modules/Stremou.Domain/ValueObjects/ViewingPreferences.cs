using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Models
{
    public class ViewingPreferences : ValueObject
    {
        public ViewingPreferences(Guid userId, List<string> preferredGenres, bool allowExplicitContent, string preferredLanguage)
        {
            UserId = userId;
            PreferredGenres = preferredGenres;
            AllowExplicitContent = allowExplicitContent;
            PreferredLanguage = preferredLanguage;
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        public Guid UserId { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public List<string> PreferredGenres { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public bool AllowExplicitContent { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string PreferredLanguage { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
            yield return PreferredGenres;
            yield return AllowExplicitContent;
            yield return PreferredLanguage;
        }
    }
}
