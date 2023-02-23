using FluentValidation;
using MVCBlogApp.Application.ViewModels;

namespace MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryCreate
{
    public class BlogCategoryCreateCommandValidator : AbstractValidator<VM_BlogCategory>
    {
        public BlogCategoryCreateCommandValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Kategori Adını boş geçmeyiniz.")
                .MinimumLength(2)
                .MaximumLength(200)
                .WithMessage("Lütfen kategori adını enaz 2 ençok 200 karakter olacak şekilde giriniz.");

            RuleFor(x => x.CategoryDescription)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Kategori Açıklamasını boş geçmeyiniz.")
                .MinimumLength(2)
                .MaximumLength(200)
                .WithMessage("Lütfen kategori açıklamasını enaz 2 ençok 500 karakter olacak şekilde giriniz.");

            RuleFor(x => x.StatusID)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangID)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
