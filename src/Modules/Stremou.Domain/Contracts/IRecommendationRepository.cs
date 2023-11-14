using Stremou.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Contracts
{
    public interface IRecommendationRepository
    {
        Task<Recommendation> GetByUserId(Guid userId);
        Task<IEnumerable<Recommendation>> GetList();
        Task Add(Recommendation recommendation);
        Task Update(Recommendation recommendation);
        Task Delete(Recommendation recommendation);
    }
}
