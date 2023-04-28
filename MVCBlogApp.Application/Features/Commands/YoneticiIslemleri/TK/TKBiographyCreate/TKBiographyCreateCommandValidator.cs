using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.YoneticiIslemleri.TK.TKBiographyCreate
{
    public class TKBiographyCreateCommandValidator : AbstractValidator<TKBiographyCreateCommandRequest>
    {
        public TKBiographyCreateCommandValidator()
        {
            RuleFor(x => x.About)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Hakkımızda bölümünü doldurunuz.");

            RuleFor(x => x.Bio)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Bio bölümünü doldurunuz.");

            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Şirket Adı bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Şirket Adı enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Adress)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Adres bölümünü doldurunuz.");

            RuleFor(x => x.Phone1)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Telefon 1 bölümünü doldurunuz.")
                .MaximumLength(24)
                .MinimumLength(2)
                .WithMessage("Lütfen Telefon 1 enaz 2 ve ençok 24 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Phone2)
                .MaximumLength(24)
                .MinimumLength(2)
                .WithMessage("Lütfen Telefon 2 enaz 2 ve ençok 24 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Email1)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Email 1 bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Email 1 enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Email2)
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Email 2 enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.FormFile)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Logo yükleyiniz.");

            RuleFor(x => x.GoogleMap)
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Google Map enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Instagram)
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Instagram enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Facebook)
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Facebook enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Twitter)
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Twitter enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Pinterest)
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Pinterest enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Metatitle)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Seo Başlığı bölümünü doldurunuz.");

            RuleFor(x => x.Metakey)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Seo Anahtarları bölümünü doldurunuz.");

            RuleFor(x => x.Metadescription)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Seo Açıklaması bölümünü doldurunuz.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangId)
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}