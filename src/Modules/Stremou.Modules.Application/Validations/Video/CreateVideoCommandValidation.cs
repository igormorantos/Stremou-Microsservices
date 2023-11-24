using FluentValidation;
using Stremou.Modules.Application.Handlers.Video.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Validations.Video
{
    public class CreateVideoCommandValidation : AbstractValidator<CreateVideoCommand>
    {
        public CreateVideoCommandValidation() 
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .WithMessage("O título não pode estar vazio.")
                .MaximumLength(100)
                .WithMessage("O título não pode ter mais de 100 caracteres.")
                .MinimumLength(2)
                .WithMessage("O título deve ter pelo menos 2 caracteres.");

            RuleFor(a => a.Description)
                .NotEmpty()
                .WithMessage("A descrição não pode estar vazia.")
                .MaximumLength(500)
                .WithMessage("A descrição não pode ter mais de 500 caracteres.");

            RuleFor(a => a.Category)
                .NotNull()
                .WithMessage("A categoria não pode ser nula.");

            RuleFor(a => a.Duration)
                .NotEmpty()
                .WithMessage("A duração não pode estar vazia.")
                .Must(duration => duration.TotalMinutes >= 1)
                .WithMessage("A duração deve ser de pelo menos 1 minuto.");

            RuleFor(a => a.VideoUrl)
                .NotEmpty()
                .WithMessage("A URL do vídeo não pode estar vazia.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("A URL do vídeo deve ser uma URL válida.");
        }
    }
}
