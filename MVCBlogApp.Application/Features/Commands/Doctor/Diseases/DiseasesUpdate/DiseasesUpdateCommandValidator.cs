using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Doctor.Diseases.DiseasesUpdate
{
    public class DiseasesUpdateCommandValidator : AbstractValidator<DiseasesUpdateCommandRequest>
    {
        public DiseasesUpdateCommandValidator()
        {
            RuleFor(x => x.DiseasesName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Hastalık Adı alanını doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Hastalık Adı enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Type)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Konu bölümünü doldurunuz.")
                .InclusiveBetween(1, 5)
                .WithMessage("Girilen Tip sayı aralığı 1 ile 5 arasında olmalıdır.");
        }
    }
}
