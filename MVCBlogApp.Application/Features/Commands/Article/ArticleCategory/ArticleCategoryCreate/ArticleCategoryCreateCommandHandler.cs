using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryCreate
{
    public class ArticleCategoryCreateCommandHandler : IRequestHandler<ArticleCategoryCreateCommandRequest, ArticleCategoryCreateCommandResponse>
    {
        private readonly IArticleService _articleService;

        public ArticleCategoryCreateCommandHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<ArticleCategoryCreateCommandResponse> Handle(ArticleCategoryCreateCommandRequest request, CancellationToken cancellationToken)
        {
            ArticleCategoryCreateCommandValidator rules = new();
            ValidationResult validationResult = rules.Validate(request);

            if (validationResult.IsValid)
            {
                return await _articleService.ArticleCategoryCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
