using FluentValidation;
using Stremou.Modules.Application.Handlers.User.Requests;
using Stremou.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Validations.User
{
    public class CheckUserExistsByCpfRequestValidation : AbstractValidator<CheckUserExistsByCpfRequest>
    {
        public CheckUserExistsByCpfRequestValidation() 
        {
            RuleFor(a => a.Cpf)
                .NotEmpty()
                .WithMessage("O CPF não pode estar vazio.")
                .Must(ValidarCpf)
                .WithMessage("O CPF deve ser válido.");
        }

        private bool ValidarCpf(Cpf cpf)
        {
            throw new NotImplementedException();
        }
    }
}
