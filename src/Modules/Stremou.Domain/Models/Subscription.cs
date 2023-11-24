using NetDevPack.Domain;

namespace Stremou.Modules.Domain.Models
{
    public class Subscription : Entity, IAggregateRoot
    {
        public Subscription(Guid userId, Guid planId, DateTime startDate, DateTime endDate)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = true;
        }

        public Guid Id { get; private set; }
            public Guid UserId { get; private set; }
            public DateTime StartDate { get; private set; }
            public DateTime EndDate { get; private set; }
            public bool IsActive { get; private set; }
        
    }
}
