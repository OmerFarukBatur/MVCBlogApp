using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Article.ArticleCategory.ArticleCategoryDelete
{
    public class ArticleCategoryDeleteCommandHandler : IRequestHandler<ArticleCategoryDeleteCommandRequest, ArticleCategoryDeleteCommandResponse>
    {
        private readonly IArticleService _articleService;

        public ArticleCategoryDeleteCommandHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<ArticleCategoryDeleteCommandResponse> Handle(ArticleCategoryDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _articleService.ArticleCategoryDeleteAsync(request.Id);
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
