using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopType.WorkshopTypeUpdate
{
    public class WorkshopTypeUpdateCommandValidator : AbstractValidator<WorkshopTypeUpdateCommandRequest>
    {
        public WorkshopTypeUpdateCommandValidator()
        {
            RuleFor(x => x.WstypeName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen alanı baoş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(3)
                .WithMessage("Lütfen girilen degeri enaz 3 ve encok 150 karakter olacak şekilde giriniz.");

            RuleFor(x => x.LangId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
