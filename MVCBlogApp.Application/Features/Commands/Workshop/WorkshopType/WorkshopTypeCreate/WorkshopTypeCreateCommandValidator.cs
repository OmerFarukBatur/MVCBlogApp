﻿using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeCreate
{
    public class WorkshopTypeCreateCommandValidator : AbstractValidator<WorkshopTypeCreateCommandRequest>
    {
        public WorkshopTypeCreateCommandValidator()
        {
            RuleFor(x => x.WstypeName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(2)
                .WithMessage("Lütfen girilen degeri enaz 2 ve encok 150 karakter olacak şekilde giriniz.");

            RuleFor(x => x.LangId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
