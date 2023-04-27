using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.GeneralOptions.ContactCategory.ContactCategoryUpdate
{
    public class ContactCategoryUpdateCommandValidator : AbstractValidator<ContactCategoryUpdateCommandRequest>
    {
        public ContactCategoryUpdateCommandValidator()
        {
            RuleFor(x => x.ContactCategoryName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen İletişim Kategori Adı bölümünü doldurunuz.")
                .MaximumLength(150)
                .MinimumLength(2)
                .WithMessage("Lütfen İletişim Kategori Adı enaz 2 ve ençok 150 karakter olacak şekilde giriniz.");

            RuleFor(x => x.LangId)
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
