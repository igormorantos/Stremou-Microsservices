using FluentValidation.Results;
using Stremou.Modules.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.User.Responses
{
    public class CreateUserResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateUserResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }
        public CreateUserResponse(Guid requestId, string failedValidations)
        {
            RequestId = requestId;
            this.AddError(failedValidations);
        }
    }
}
