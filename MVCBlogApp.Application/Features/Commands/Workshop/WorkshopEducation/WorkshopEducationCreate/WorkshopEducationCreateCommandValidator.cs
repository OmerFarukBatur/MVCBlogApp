using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Workshop.WorkshopEducation.WorkshopEducationCreate
{
    public class WorkshopEducationCreateCommandValidator : AbstractValidator<WorkshopEducationCreateCommandRequest>
    {
        public WorkshopEducationCreateCommandValidator()
        {
            RuleFor(x => x.WsEducationName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen alanı boş geçmeyiniz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen girilen degeri enaz 2 ve encok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.LangId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Dil şeçiniz.");

            RuleFor(x => x.StatusId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.WscategoryId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Eğitim Kategorisi şeçiniz.");
        }
    }
}
