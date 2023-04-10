using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.File.Banner.BannerCreate
{
    public class BannerCreateCommandValidator : AbstractValidator<BannerCreateCommandRequest>
    {
        public BannerCreateCommandValidator()
        {
            RuleFor(x => x.BannerName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Banner Adı bölümünü doldurunuz.")
                .MaximumLength(150)
                .MinimumLength(2)
                .WithMessage("Lütfen Banner Adını enaz 2 ve ençok 150 karakter olacak şekilde giriniz.");

            RuleFor(x => x.BannerOrder)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Banner Sırası bölümünü doldurunuz.")
                .GreaterThan(0)
                .WithMessage("Girilen değer sıfırdan büyük olmalıdır.");

            RuleFor(x => x.FormFile)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Kapak Fotoğrafı yükleyiniz.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangId)
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
