using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhUpdate
{
    public class FixBmhUpdateCommandValidator : AbstractValidator<FixBmhUpdateCommandRequest>
    {
        public FixBmhUpdateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Başlık bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Başlık enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(s => s.FormId)
                .NotNull()
                .WithMessage("Lütfen bir Form Tipi seçiniz.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Açıklama bölümünü doldurunuz.");

            RuleFor(x => x.LangId)
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");
        }
    }
}
