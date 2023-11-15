using Stremou.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Contracts
{
    public interface IVideoRepository
    {
        Task<Video> GetByVideoUrl(string videoUrl);

        Task<Video> GetByName(string name);

        Task<IEnumerable<Video>> GetAllAsync();

        Task Add(Video video);

        Task Update(Video video);

        Task Delete(Video video);
    }
}
