using FluentValidation;
using Stremou.Modules.Application.Handlers.Video.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stremou.Modules.Application.Validations.Video
{
    public class CheckVideoExistsByNameRequestValidation : AbstractValidator<CheckVideoExistsByNameRequest>
    {
    }
}
