using MediatR;
using Microsoft.Extensions.Logging;
using NetDevPack.Messaging;
using Stremou.Domain.Contracts;
using Stremou.Modules.Application.Handlers.Video.Commands;
using Stremou.Modules.Application.Handlers.Video.Responses;
using Stremou.Modules.Application.Validations.Video;
using System.Text.Json;

namespace Stremou.Modules.Application.Handlers.Video.Handlers
{
    public class CreateVideoHandler : IRequestHandler<CreateVideoCommand, CreateVideoResponse>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly ILogger<CreateVideoHandler> _logger;

        public CreateVideoHandler(IVideoRepository videoRepository, ILogger<CreateVideoHandler> logger)
        {
            _videoRepository = videoRepository;
            _logger = logger;
        }
        public async Task<CreateVideoResponse> Handle(CreateVideoCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateUserCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateVideoCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var VideoUrl = await _videoRepository.GetByVideoUrl(command.VideoUrl);
                    var VideoTitle = await _videoRepository.GetByName(command.Title);

                    if (VideoUrl != null && VideoTitle != null)
                        return await Task.FromResult(new CreateVideoResponse(command.Id, "User Alredy Exists"));

                    await _videoRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateVideoResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateVideoResponse(command.Id, "Não foi possivel Processar solicitação."));

                }
            }
            return await Task.FromResult(new CreateVideoResponse(command.Id, validationResult));
        }
    }
}
