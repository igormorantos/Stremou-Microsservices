using AutoMapper;
using Microsoft.Extensions.Logging;
using Stremou.Domain.Contracts;
using Stremou.Domain.Models;
using Stremou.Modules.Application.Handlers.Video.Commands;

namespace Stremou.Modules.Application.Services.Implementations
{
    public class VideoAppService : IVideoAppService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public VideoAppService(IVideoRepository videoRepository, IMapper mapper, ILogger logger)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<VideoViewModel> GetByName(string name)
        {
            return _mapper.Map<VideoViewModel>(await _videoRepository.GetByName(name));
        }

        public async Task<VideoViewModel> GetbyVideoUrl(string url)
        {
            return _mapper.Map<VideoViewModel>(await _videoRepository.GetByVideoUrl(url));

        }

        public async Task Save(CreateVideoCommand commandCreate)
        {
            await _videoRepository.Add(commandCreate.GetEntity());
        }
    }
}
