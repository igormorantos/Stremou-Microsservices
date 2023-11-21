using Stremou.Domain.Models;
using Stremou.Modules.Application.Handlers.Video.Commands;

namespace Stremou.Domain.Contracts
{
    public interface IVideoAppService
    {
        Task<VideoViewModel> GetbyVideoUrl(string url);

        Task<VideoViewModel> GetByName(string name);

        Task Save(CreateVideoCommand commandCreate);
    }
}
