using FluentValidation;
using Stremou.Modules.Application.Handlers.User.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Validations.User
{
    public class CheckUserExistsByEmailRequestValidation : AbstractValidator<CheckUserExistsByEmailRequest>
    {
        public CheckUserExistsByEmailRequestValidation() 
        {
            RuleFor(a => a.Email)
                .NotEmpty()
                .WithMessage("O email não pode estar vazio.")
                .EmailAddress()
                .WithMessage("O email deve ser um endereço de email válido.");
        }
    }
}
