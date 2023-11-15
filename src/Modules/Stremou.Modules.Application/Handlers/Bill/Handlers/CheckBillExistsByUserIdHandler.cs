using MediatR;
using Microsoft.Extensions.Logging;
using Stremou.Domain.Contracts;
using Stremou.Modules.Application.Handlers.Bill.Requests;
using Stremou.Modules.Application.Handlers.Bill.Responses;
using Stremou.Modules.Application.Handlers.User.Responses;
using Stremou.Modules.Application.Validations.Bill;
using Stremou.Modules.Application.Validations.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.Bill.Handlers
{
    public class CheckBillExistsByUserIdHandler : IRequestHandler<CheckBillExistsByUserIdRequest, CheckBillExistsByUserIdResponse>
    {
        private readonly IBillRepository _billRepository;
        private readonly ILogger<CheckBillExistsByUserIdHandler> _logger;

        public CheckBillExistsByUserIdHandler(IBillRepository billRepository, ILogger<CheckBillExistsByUserIdHandler> logger)
        {
            _billRepository = billRepository;
            _logger = logger;
        }

        public async Task<CheckBillExistsByUserIdResponse> Handle(CheckBillExistsByUserIdRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckBillExistsByUserIdRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckBillExistsByUserIdRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var UserName = await _billRepository.GetByUserID(request.UserId);

                    if (UserName != null)
                        return await Task.FromResult(new CheckBillExistsByUserIdResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckBillExistsByUserIdResponse(request.Id, "Não foi possivel Processar solicitação."));
                }
            }

            return await Task.FromResult(new CheckBillExistsByUserIdResponse(request.Id, false, validationResult));

        }
    }
}
