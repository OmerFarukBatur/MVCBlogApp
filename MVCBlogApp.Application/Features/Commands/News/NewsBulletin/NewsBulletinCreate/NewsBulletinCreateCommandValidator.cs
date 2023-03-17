using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.News.NewsBulletin.NewsBulletinCreate
{
    public class NewsBulletinCreateCommandValidator : AbstractValidator<NewsBulletinCreateCommandRequest>
    {
        public NewsBulletinCreateCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Email'i boş geçmeyiniz.")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir email adresi giriniz.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");
        }
    }
}
