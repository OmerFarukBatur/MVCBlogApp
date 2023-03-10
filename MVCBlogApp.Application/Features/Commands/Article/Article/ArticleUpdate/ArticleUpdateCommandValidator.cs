using FluentValidation;

namespace MVCBlogApp.Application.Features.Commands.Article.Article.ArticleUpdate
{
    public class ArticleUpdateCommandValidator : AbstractValidator<ArticleUpdateCommandRequest>
    {
        public ArticleUpdateCommandValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Sayfa Adı bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Sayfa Adını enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.UrlRoot)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Seo URL bölümünü doldurunuz.")
                .MaximumLength(350)
                .MinimumLength(2)
                .WithMessage("Lütfen Seo URL enaz 2 ve ençok 350 karakter olacak şekilde giriniz.");

            RuleFor(s => s.ArticleCategoryId)
                .NotNull()
                .WithMessage("Lütfen bir Sayfa Etiketi seçiniz.");

            RuleFor(x => x.NavigationId)
               .NotNull()
               .WithMessage("Lütfen bir İlişkili Navigasyon şeçiniz.");

            RuleFor(x => x.MetaTitle)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Seo Title bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Seo Title enaz 2 ve ençok 150 karakter olacak şekilde giriniz.");

            RuleFor(x => x.MetaKey)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Seo Kelimeleri bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Seo Kelimeleri enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.MetaDescription)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Seo Açıklaması bölümünü doldurunuz.")
                .MaximumLength(300)
                .MinimumLength(2)
                .WithMessage("Lütfen Seo Açıklaması enaz 2 ve ençok 300 karakter olacak şekilde giriniz.");

            RuleFor(x => x.IsMainPage)
               .NotNull()
               .WithMessage("Lütfen bir Ana Sayfa durumunu şeçiniz.");

            RuleFor(x => x.IsMenu)
               .NotNull()
               .WithMessage("Lütfen bir Navigasyon durumunu şeçiniz.");

            RuleFor(x => x.IsComponent)
               .NotNull()
               .WithMessage("Lütfen bir Footer (Hızlı Erişim) durumunu şeçiniz.");

            RuleFor(x => x.IsNewsComponent)
               .NotNull()
               .WithMessage("Lütfen bir Alt Bülten durumunu şeçiniz.");

            RuleFor(x => x.SubTitle)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Sayfa Özeti bölümünü doldurunuz.")
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("Lütfen Sayfa Özeti enaz 2 ve ençok 250 karakter olacak şekilde giriniz.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen İçerik bölümünü doldurunuz.");

            RuleFor(x => x.LangId)
                .NotNull()
                .WithMessage("Lütfen bir Dil şeçiniz.");

            RuleFor(x => x.StatusId)
               .NotNull()
               .WithMessage("Lütfen bir Durum şeçiniz.");
        }
    }
}
