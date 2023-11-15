using Stremou.Domain.Models;
using Stremou.Modules.Application.Handlers.User.Commands;
using Stremou.Modules.Application.Handlers.Video.Commands;
using Stremou.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Domain.Contracts
{
    public interface IVideoAppService
    {
        Task<VideoViewModel> GetbyVideoUrl(string url);

        Task<VideoViewModel> GetByName(string name);

        Task Save(CreateVideoCommand commandCreate);
    }
}
