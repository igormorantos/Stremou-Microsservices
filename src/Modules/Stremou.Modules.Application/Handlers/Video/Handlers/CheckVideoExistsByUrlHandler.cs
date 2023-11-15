using MediatR;
using Microsoft.Extensions.Logging;
using Stremou.Domain.Contracts;
using Stremou.Modules.Application.Handlers.User.Responses;
using Stremou.Modules.Application.Handlers.Video.Requests;
using Stremou.Modules.Application.Handlers.Video.Responses;
using Stremou.Modules.Application.Validations.User;
using Stremou.Modules.Application.Validations.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.Video.Handlers
{
    public class CheckVideoExistsByUrlHandler : IRequestHandler<CheckVideoExistsByUrlRequest, CheckVideoExistsByUrlResponse>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly ILogger<CheckVideoExistsByUrlHandler> _logger;

        public CheckVideoExistsByUrlHandler(IVideoRepository videoRepository, ILogger<CheckVideoExistsByUrlHandler> logger)
        {
            _videoRepository = videoRepository;
            _logger = logger;
        }

        public async Task<CheckVideoExistsByUrlResponse> Handle(CheckVideoExistsByUrlRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckVideoExistsByUrlRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckVideoExistsByUrlRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var UserName = await _videoRepository.GetByVideoUrl(request.VideoUrl);

                    if (UserName != null)
                        return await Task.FromResult(new CheckVideoExistsByUrlResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckVideoExistsByUrlResponse(request.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CheckVideoExistsByUrlResponse(request.Id, false, validationResult));

        }
    }
}
