using AIProject.Application.Common.Interfaces;
using AIProject.Application.Features.Chat.Commands.CreateChat;
using AIProject.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Validators.Chat
{
    public class CreateChatValidator : AbstractValidator<CreateChatCommand>
    {
        private readonly IEnglishDegreeService _englishDegreeService;
        private readonly IPromptService _promptService;

        public CreateChatValidator(IEnglishDegreeService englishDegreeService, IPromptService promptService)
        {
            _englishDegreeService = englishDegreeService;
            _promptService = promptService;


            RuleFor(x => x.Subject).NotEmpty().WithMessage("Boş bırakılamaz");
            RuleFor(x => x.EnglishDegreeId).NotEmpty().WithMessage("Boş bırakılamaz");
            RuleFor(x => x.PromptId).NotEmpty().WithMessage("Boş bırakılamaz");

            RuleFor(x => x.EnglishDegreeId).Must(IsValidDegree).WithMessage("degree yok amk");//must false ise patlar.
            RuleFor(x => x.PromptId).Must(IsValidPromptId).WithMessage("promptid yok amk");
        }

        private bool IsValidDegree(string degree)
        {
            return _englishDegreeService.IsEnglishDegreeIdValid(degree);
        }
        private bool IsValidPromptId(string promptId)
        {
            return _promptService.IsPromptIdValid(promptId);
        }

    }
}
