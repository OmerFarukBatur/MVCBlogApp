using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsUpdate
{
    public class SeminarVisualsUpdateCommandValidator : AbstractValidator<SeminarVisualsUpdateCommandRequest>
    {
        public SeminarVisualsUpdateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Seminer Başlığı alanını doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Seminer Başlığı enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.sCreateDate)
               .NotNull()
               .WithMessage("Lütfen bir Seminer Tarihi giriniz.");

            RuleFor(x => x.Location)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Lokasyon alanını doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Lokasyon enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Haber İçeriği alanını boş bırakmayınız.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangId)
               .NotNull()
               .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
