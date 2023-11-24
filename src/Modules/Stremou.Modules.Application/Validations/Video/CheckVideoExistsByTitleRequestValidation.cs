using FluentValidation;
using Stremou.Modules.Application.Handlers.Video.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Validations.Video
{
    public class CheckVideoExistsByTitleRequestValidation : AbstractValidator<CheckVideoExistsByTitleRequest>
    {
        public CheckVideoExistsByTitleRequestValidation()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .WithMessage("O título não pode estar vazio.")
                .MaximumLength(100)
                .WithMessage("O título não pode ter mais de 100 caracteres.")
                .MinimumLength(2)
                .WithMessage("O título deve ter pelo menos 2 caracteres.");
        }
    }
}
