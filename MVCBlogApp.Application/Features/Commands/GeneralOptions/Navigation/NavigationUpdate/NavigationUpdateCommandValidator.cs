using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.Navigation.NavigationUpdate
{
    public class NavigationUpdateCommandValidator : AbstractValidator<NavigationUpdateCommandRequest>
    {
        public NavigationUpdateCommandValidator() 
        {
            RuleFor(x => x.MetaTitle)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen MetaTitle bölümünü boş geçmeyiniz.");

            RuleFor(x => x.NavigationName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen NavigationName bölümünü boş geçmeyiniz.");

            RuleFor(x => x.IsActive)
                .NotNull()
                .WithMessage("Lütfen bir Rol şeçiniz.");

            RuleFor(x => x.LangId)
                .NotNull()
                .WithMessage("Lütfen bir Rol şeçiniz.");

            RuleFor(x => x.IsAdmin)
                .NotNull()
                .WithMessage("Lütfen bir Rol şeçiniz.");
        }
    }
}
