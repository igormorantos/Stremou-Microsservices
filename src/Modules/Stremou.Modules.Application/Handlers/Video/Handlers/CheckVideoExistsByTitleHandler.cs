using MediatR;
using Microsoft.Extensions.Logging;
using Stremou.Domain.Contracts;
using Stremou.Modules.Application.Handlers.Video.Requests;
using Stremou.Modules.Application.Handlers.Video.Responses;
using Stremou.Modules.Application.Validations.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.Video.Handlers
{
    public class CheckVideoExistsByTitleHandler : IRequestHandler<CheckVideoExistsByTitleRequest, CheckVideoExistsByTitleResponse>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly ILogger<CheckVideoExistsByUrlHandler> _logger;

        public CheckVideoExistsByTitleHandler(IVideoRepository videoRepository, ILogger<CheckVideoExistsByUrlHandler> logger)
        {
            _videoRepository = videoRepository;
            _logger = logger;
        }
        public async Task<CheckVideoExistsByTitleResponse> Handle(CheckVideoExistsByTitleRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckVideoExistsByNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckVideoExistsByTitleRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var UserName = await _videoRepository.GetByTitle(request.Title);

                    if (UserName != null)
                        return await Task.FromResult(new CheckVideoExistsByTitleResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckVideoExistsByTitleResponse(request.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CheckVideoExistsByTitleResponse(request.Id, false, validationResult));

        }
    }
}
