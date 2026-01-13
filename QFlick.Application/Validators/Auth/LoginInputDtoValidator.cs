using FluentValidation;
using QFlick.Domain.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Application.Validators.Auth
{
    public sealed class LoginInputDtoValidator : AbstractValidator<LoginInputDto>
    {
        public LoginInputDtoValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty()
                    .WithMessage("Email is required")
                .EmailAddress()
                    .WithMessage("Email is not valid");
        }
    }
}
