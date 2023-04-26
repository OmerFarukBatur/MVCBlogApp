using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerCreate
{
    public class InfluencerCreateCommandValidator : AbstractValidator<InfluencerCreateCommandRequest>
    {
        public InfluencerCreateCommandValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Ad Soyad alanını doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Ad Soyadı enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Email alanını doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Email enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Telefon Numarası alanını doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Telefon Numarası enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Firma Adı alanını doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Firma Adı enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.CompanySector)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Firma Sektörü alanını doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Firma Sektörü enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Message)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Mesaj alanını boş bırakmayınız.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");
        }
    }
}
