using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.ConsultancyForms.ConsultancyFormsCreate
{
    public class ConsultancyFormsCreateCommandValidator : AbstractValidator<ConsultancyFormsCreateCommandRequest>
    {
        public ConsultancyFormsCreateCommandValidator()
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
                .MaximumLength(14)
                .WithMessage("Lütfen Telefon Numarasını maksimum 14 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Subject)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Konu Başlığını boş geçmeyiniz.")
                .MaximumLength(500)
                .WithMessage("Lütfen Konu Başlığını maksimum 500 karakter olacak şekilde giriniz.");

            RuleFor(x => x.id)
                .NotEmpty()
                .NotNull();
        }
    }
}
