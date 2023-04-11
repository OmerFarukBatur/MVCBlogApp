using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.File.Carousel.CarouselUpdate
{
    public class CarouselUpdateCommandValidator : AbstractValidator<CarouselUpdateCommandRequest>
    {
        public CarouselUpdateCommandValidator()
        {
            RuleFor(x => x.MetaTitle)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen MetaTitle bölümünü doldurunuz.")
               .MaximumLength(150)
               .MinimumLength(2)
               .WithMessage("Lütfen MetaTitle enaz 2 ve ençok 150 karakter olacak şekilde giriniz.");

            RuleFor(x => x.MetaKey)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen MetaKey bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen MetaKey enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.MetaDescription)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen MetaDescription bölümünü doldurunuz.")
                .MaximumLength(300)
                .MinimumLength(2)
                .WithMessage("Lütfen MetaDescription enaz 2 ve ençok 300 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Ad bölümünü doldurunuz.")
                .MaximumLength(150)
                .MinimumLength(2)
                .WithMessage("Lütfen Adı enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.UrlRoot)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen UrlRoot bölümünü doldurunuz.")
                .MaximumLength(300)
                .MinimumLength(2)
                .WithMessage("Lütfen UrlRoot enaz 2 ve ençok 400 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Orders)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Slider Sırası bölümünü doldurunuz.")
                .GreaterThan(0)
                .WithMessage("Girilen değer sıfırdan büyük olmalıdır.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangId)
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
