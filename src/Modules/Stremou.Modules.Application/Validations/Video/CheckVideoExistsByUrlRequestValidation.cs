using FluentValidation;
using Stremou.Modules.Application.Handlers.Video.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Validations.Video
{
    public class CheckVideoExistsByUrlRequestValidation : AbstractValidator<CheckVideoExistsByUrlRequest>
    {
        public CheckVideoExistsByUrlRequestValidation() 
        {
            RuleFor(a => a.VideoUrl)
                .NotEmpty()
                .WithMessage("A URL do vídeo não pode estar vazia.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("A URL do vídeo deve ser uma URL válida.");
        }
    }
}
