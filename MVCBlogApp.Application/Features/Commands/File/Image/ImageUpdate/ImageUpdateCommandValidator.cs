using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.File.Image.ImageUpdate
{
    public class ImageUpdateCommandValidator : AbstractValidator<ImageUpdateCommandRequest>
    {
        public ImageUpdateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Başlık bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Başlık bölümünü enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangId)
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");

            RuleFor(x => x.IsCover)
               .NotNull()
               .WithMessage("Lütfen bir Kapak durumu şeçiniz.");
        }
    }
}
