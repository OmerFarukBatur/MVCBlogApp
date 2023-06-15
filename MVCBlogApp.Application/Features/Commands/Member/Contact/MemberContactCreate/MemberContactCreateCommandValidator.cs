using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Member.Contact.MemberContactCreate
{
    public class MemberContactCreateCommandValidator : AbstractValidator<MemberContactCreateCommandRequest>
    {
        public MemberContactCreateCommandValidator()
        {
            RuleFor(x => x.NameSurname)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen Ad'ı boş geçmeyiniz.")
            .MaximumLength(250)
            .WithMessage("Lütfen Adı ve Soyadınızı maksimum 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Email'i boş geçmeyiniz.")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir email adresi giriniz.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Telefon Numarası'nı boş geçmeyiniz.")
                .MaximumLength(250)
                .WithMessage("Lütfen Telefon Numarasını maksimum 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Subject)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen Konu alanını boş geçmeyiniz.")
            .MaximumLength(100)
            .WithMessage("Lütfen Adı ve Soyadınızı maksimum 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Açıklama bölümünü doldurunuz.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.ContactCategoryId)
                .NotNull()
                .WithMessage("Lütfen bir İletişim Kategorisi şeçiniz.");
        }
    }
}
