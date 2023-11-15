using MediatR;
using Microsoft.Extensions.Logging;
using NetDevPack.Messaging;
using Stremou.Domain.Contracts;
using Stremou.Modules.Application.Handlers.Bill.Commands;
using Stremou.Modules.Application.Handlers.Bill.Responses;
using Stremou.Modules.Application.Handlers.Video.Responses;
using Stremou.Modules.Application.Validations.Bill;
using Stremou.Modules.Application.Validations.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.Bill.Handlers
{
    public class CreateBillHandler : IRequestHandler<CreateBillCommand, CreateBillResponse>
    {
        private readonly IBillRepository _billRepository;
        private readonly ILogger<CreateBillHandler> _logger;

        public CreateBillHandler(IBillRepository billRepository, ILogger<CreateBillHandler> logger)
        {
            _billRepository = billRepository;
            _logger = logger;
        }

        public async Task<CreateBillResponse> Handle(CreateBillCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateBillCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateBillCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var UserId = await _billRepository.GetByUserID(command.UserId);

                    if (UserId != null)
                        return await Task.FromResult(new CreateBillResponse(command.Id, "User Alredy Exists"));

                    await _billRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateBillResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateBillResponse(command.Id, "Não foi possivel Processar solicitação."));

                }
            }
            return await Task.FromResult(new CreateBillResponse(command.Id, validationResult));
        }
    }
}
