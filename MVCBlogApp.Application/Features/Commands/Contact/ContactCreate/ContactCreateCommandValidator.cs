using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Contact.ContactCreate
{
    public class ContactCreateCommandValidator : AbstractValidator<ContactCreateCommandRequest>
    {
        public ContactCreateCommandValidator()
        {
            RuleFor(x => x.NameSurname)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen Ad'ı boş geçmeyiniz.")
            .MaximumLength(250)
            .WithMessage("Lütfen Adı ve Soyadınızı maksimum 200 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Email'i boş geçmeyiniz.")
                .EmailAddress()
                .MaximumLength(250)
                .WithMessage("Lütfen geçerli bir email adresi giriniz.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Telefon Numarası'nı boş geçmeyiniz.")
                .MaximumLength(25)
                .WithMessage("Lütfen Telefon Numarasını maksimum 25 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Subject)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Konu Başlığını boş geçmeyiniz.")
                .MaximumLength(100)
                .WithMessage("Lütfen Konu Başlığını maksimum 100 karakter olacak şekilde giriniz.");
        }
    }
}
