﻿using FluentValidation.Results;
using Stremou.Modules.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Handlers.User.Responses
{
    public class CheckUserExistsByEmailResponse : Response
    {
        public Guid RequestId { get; private set; }
        public bool Exists { get; set; }

        public CheckUserExistsByEmailResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }
        public CheckUserExistsByEmailResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
    }
}
