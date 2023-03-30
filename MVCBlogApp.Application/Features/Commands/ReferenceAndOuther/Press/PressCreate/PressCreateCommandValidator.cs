using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Press.PressCreate
{
    public class PressCreateCommandValidator : AbstractValidator<PressCreateCommandRequest>
    {
        public PressCreateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Haber Başlığı bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Haber Başlığı enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.UrlRoot)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Seo URL bölümünü doldurunuz.")
                .MaximumLength(400)
                .MinimumLength(2)
                .WithMessage("Lütfen Seo URL enaz 2 ve ençok 400 karakter olacak şekilde giriniz.");

            RuleFor(x => x.MetaTitle)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Seo Title bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Seo Title enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.MetaKey)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Seo Kelimeleri bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Seo Kelimeleri enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.MetaDescription)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Seo Açıklaması bölümünü doldurunuz.")
                .MaximumLength(400)
                .MinimumLength(2)
                .WithMessage("Lütfen Seo Açıklaması enaz 2 ve ençok 400 karakter olacak şekilde giriniz.");

            RuleFor(x => x.UrlLink)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Uzak Bağlantı Linki bölümünü doldurunuz.")
                .MaximumLength(400)
                .MinimumLength(2)
                .WithMessage("Lütfen Uzak Bağlantı Linki enaz 2 ve ençok 400 karakter olacak şekilde giriniz.");

            RuleFor(x => x.NewsPaperId)
               .NotNull()
               .WithMessage("Lütfen bir Gazete şeçiniz.");

            RuleFor(x => x.PressTypeId)
               .NotNull()
               .WithMessage("Lütfen bir Tip şeçiniz.");

            RuleFor(x => x.FormFile)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Kapak Fotoğrafı yükleyiniz.");

            RuleFor(x => x.SubTitle)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Haber Özeti bölümünü doldurunuz.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Haber İçeriği bölümünü doldurunuz.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Haber Durumu şeçiniz.");

            RuleFor(x => x.LangId)
                .NotNull()
                .WithMessage("Lütfen bir Haber Dili şeçiniz.");

        }
    }
}
