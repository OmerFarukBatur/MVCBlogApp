using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Features.Commands.BlogCategory.BlogCategoryUpdate
{
    public class BlogCategoryUpdateQueryValidator : AbstractValidator<BlogCategoryUpdateQueryRequest>
    {
        public BlogCategoryUpdateQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id 0 dan küçük olamaz.");

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

            RuleFor(x => x.StatusId)
                .NotNull()
                .WithMessage("Lütfen bir Durum şeçiniz.");

            RuleFor(x => x.LangId)
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");
        }
    }
}
