using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.BookCategory.BookCategoryCreate
{
    public class BookCategoryCreateCommandValidator : AbstractValidator<BookCategoryCreateCommandRequest>
    {
        public BookCategoryCreateCommandValidator() 
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Kategori Adını boş geçmeyiniz.")
                .MinimumLength(2)
                .MaximumLength(250)
                .WithMessage("Lütfen kategori adını enaz 2 ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.StatusId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
