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
    public class CheckVideoExistsByNameHandler : IRequestHandler<CheckVideoExistsByNameRequest, CheckVideoExistsByNameResponse>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly ILogger<CheckVideoExistsByUrlHandler> _logger;

        public CheckVideoExistsByNameHandler(IVideoRepository videoRepository, ILogger<CheckVideoExistsByUrlHandler> logger)
        {
            _videoRepository = videoRepository;
            _logger = logger;
        }
        public async Task<CheckVideoExistsByNameResponse> Handle(CheckVideoExistsByNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckVideoExistsByNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckVideoExistsByNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var UserName = await _videoRepository.GetByName(request.Name);

                    if (UserName != null)
                        return await Task.FromResult(new CheckVideoExistsByNameResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckVideoExistsByNameResponse(request.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CheckVideoExistsByNameResponse(request.Id, false, validationResult));

        }
    }
}
