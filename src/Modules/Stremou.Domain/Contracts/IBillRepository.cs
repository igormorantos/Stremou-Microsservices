using Stremou.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Contracts
{
    public interface IBillRepository
    {
        Task<Bill> GetByUserID(Guid id);

        Task<IEnumerable<User>> GetList();

        Task Add(Bill bill);

        void Update(Bill bill);

        void Remove(Bill bill);
    }
}
