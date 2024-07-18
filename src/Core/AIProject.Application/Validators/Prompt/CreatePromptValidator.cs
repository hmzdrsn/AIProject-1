using AIProject.Application.Features.Prompt.Commands.CreatePrompt;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Validators.Prompt
{
    public class CreatePromptValidator : AbstractValidator<CreatePromptCommand>
    {
        public CreatePromptValidator()
        {
            RuleFor(x => x.PromptText).NotEmpty().WithMessage("Prompt Text Boş Olamaz!");
            RuleFor(x => x.PromptName).NotEmpty().WithMessage("Prompt Name Boş Olamaz!");
        }
    }
}
