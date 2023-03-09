using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Article.Article.ArticleCreate
{
    public class ArticleCreateCommandHandler : IRequestHandler<ArticleCreateCommandRequest, ArticleCreateCommandResponse>
    {
        private readonly IArticleService _articleService;

        public ArticleCreateCommandHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<ArticleCreateCommandResponse> Handle(ArticleCreateCommandRequest request, CancellationToken cancellationToken)
        {
            ArticleCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _articleService.ArticleCreateAsync(request);
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
