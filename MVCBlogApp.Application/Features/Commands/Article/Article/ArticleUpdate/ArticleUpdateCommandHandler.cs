using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Article.Article.ArticleUpdate
{
    public class ArticleUpdateCommandHandler : IRequestHandler<ArticleUpdateCommandRequest, ArticleUpdateCommandResponse>
    {
        private readonly IArticleService _articleService;

        public ArticleUpdateCommandHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<ArticleUpdateCommandResponse> Handle(ArticleUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            ArticleUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _articleService.ArticleUpdateAsync(request);
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
