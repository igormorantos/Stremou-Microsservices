using MediatR;
using Microsoft.Extensions.Logging;
using NetDevPack.Messaging;
using Stremou.Domain.Contracts;
using Stremou.Modules.Application.Handlers.User.Commands;
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
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(IUserRepository userRepository, ILogger<CreateUserHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateUserCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateUserCommandValidations().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var userEmail = await _userRepository.GetByEmail(command.Email);
                    var userName = await _userRepository.GetByCpf(command.Cpf);
                    
                    if (userName != null && userEmail != null)
                        return await Task.FromResult(new CreateUserResponse(command.Id, "User Alredy Exists"));

                    await _userRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateUserResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateUserResponse(command.Id, "Não foi possivel Processar solicitação."));

                }
            }
            return await Task.FromResult(new CreateUserResponse(command.Id, validationResult));
        }

    }
}
