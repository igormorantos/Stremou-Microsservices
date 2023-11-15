using MediatR;
using Microsoft.Extensions.Logging;
using Stremou.Domain.Contracts;
using Stremou.Modules.Application.Handlers.User.Requests;
using Stremou.Modules.Application.Handlers.User.Responses;
using Stremou.Modules.Application.Validations.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.User.Handlers
{
    public class CheckUserExistsByCpfHandler : IRequestHandler<CheckUserExistsByCpfRequest, CheckUserExistsByCpfResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CheckUserExistsByCpfHandler> _logger;

        public CheckUserExistsByCpfHandler(IUserRepository userRepository, ILogger<CheckUserExistsByCpfHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<CheckUserExistsByCpfResponse> Handle(CheckUserExistsByCpfRequest request, CancellationToken cancellationToken)
        {

            _logger.LogInformation($"CheckUserExistsByNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckUserExistsByNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var UserName = await _userRepository.GetByCpf(request.Cpf);

                    if (UserName != null)
                        return await Task.FromResult(new CheckUserExistsByCpfResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckUserExistsByCpfResponse(request.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CheckUserExistsByCpfResponse(request.Id, false, validationResult));
        }
    }
}
