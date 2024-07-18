using AIProject.Application.Common.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Validators.Auth
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş bırakılamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş bırakılamaz");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Mail Formatı Yanlış");

        }
    }
}
