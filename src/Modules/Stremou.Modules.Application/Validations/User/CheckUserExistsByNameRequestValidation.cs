using FluentValidation;
using Stremou.Modules.Application.Handlers.User.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Validations.User
{
    public class CheckUserExistsByNameRequestValidation : AbstractValidator<CheckUserExistsByCpfRequest>
    {

    }
}
