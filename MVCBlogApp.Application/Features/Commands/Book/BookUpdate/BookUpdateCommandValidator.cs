using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Book.BookUpdate
{
    public class BookUpdateCommandValidator : AbstractValidator<BookUpdateCommandRequest>
    {
        public BookUpdateCommandValidator() 
        {
            RuleFor(x => x.BookName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Kitap Adı bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Kitap Adını enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleForEach(s => s.BookCategoryId)
                .Must(
                        (f, v) =>
                        {
                            if (v > 0)
                                return true;
                            return false;
                        }
                        )
                .WithMessage("Lütfen bir kategori seçiniz.");

            RuleFor(h => h.PublicationYear)
                           .NotEmpty()
                           .NotNull()
                           .WithMessage("Lütfen bir yayın yılı giriniz.")
                           .InclusiveBetween(1000, 9999)
                           .WithMessage("Lütfen yayın yılını enaz 1000 ve ençok 9999 olacak şekilde giriniz.");

            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen İçerik bölümünü doldurunuz.");

            RuleFor(x => x.StatusId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");

            RuleFor(x => x.NavigationId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");
        }
    }
}
