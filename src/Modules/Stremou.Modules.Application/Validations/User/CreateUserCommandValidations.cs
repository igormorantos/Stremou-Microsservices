using FluentValidation;
using Stremou.Modules.Application.Handlers.User.Commands;
using Stremou.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Validations.User
{
    public class CreateUserCommandValidations : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidations() 
        {
            RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("O nome não pode estar vazio.")
            .MaximumLength(100)
            .WithMessage("O nome não pode ter mais de 100 caracteres.")
            .MinimumLength(2)
            .WithMessage("O nome deve ter pelo menos 2 caracteres.");

            RuleFor(a => a.Email)
                .NotEmpty()
                .WithMessage("O email não pode estar vazio.")
                .EmailAddress()
                .WithMessage("O email deve ser um endereço de email válido.");

            RuleFor(a => a.Password)
                .NotEmpty()
                .WithMessage("A senha não pode estar vazia.")
                .MinimumLength(8)
                .WithMessage("A senha deve ter pelo menos 8 caracteres.")
                .Matches(@"[A-Z]")
                .WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches(@"[a-z]")
                .WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches(@"[0-9]")
                .WithMessage("A senha deve conter pelo menos um número.")
                .Matches(@"[^a-zA-Z0-9]")
                .WithMessage("A senha deve conter pelo menos um caractere especial.");

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
