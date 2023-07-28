using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.UIWorkShop.CreateWorkShopApplicationForm
{
    public class CreateWorkShopApplicationFormCommandValidator : AbstractValidator<CreateWorkShopApplicationFormCommandRequest>
    {
        public CreateWorkShopApplicationFormCommandValidator()
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

            RuleFor(x => x.WorkShopId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.BirthDate)
                .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Doğum Tarihi giriniz.");

            RuleFor(x => x.Job)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Meslek alanını boş bırakmayınız.")
                .MaximumLength(250)
                .WithMessage("Girilen değer en fazla 250 karakter olmalıdır.");

            RuleFor(x => x.Gender)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Address)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Adres alanını boş bırakmayınız.")
                .MaximumLength(350)
                .WithMessage("Girilen değer en fazla 350 karakter olmalıdır.");

            RuleFor(x => x.HearAboutusId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.AttendancePurpose)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Katılım Amacı alanını boş bırakmayınız.")
                .MaximumLength(350)
                .WithMessage("Girilen değer en fazla 350 karakter olmalıdır.");

            RuleFor(x => x.LifeContented)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Diet)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Note)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Notlar alanını boş bırakmayınız.")
                .MaximumLength(350)
                .WithMessage("Girilen değer en fazla 350 karakter olmalıdır.");
        }
    }
}
