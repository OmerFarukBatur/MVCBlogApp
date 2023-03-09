using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryUpdate
{
    public class ArticleCategoryUpdateCommandHandler : IRequestHandler<ArticleCategoryUpdateCommandRequest, ArticleCategoryUpdateCommandResponse>
    {
        private readonly IArticleService _articleService;

        public ArticleCategoryUpdateCommandHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<ArticleCategoryUpdateCommandResponse> Handle(ArticleCategoryUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            ArticleCategoryUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _articleService.ArticleCategoryUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
