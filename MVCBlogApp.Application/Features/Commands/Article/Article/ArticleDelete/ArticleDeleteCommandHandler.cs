using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Article.Article.ArticleDelete
{
    public class ArticleDeleteCommandHandler : IRequestHandler<ArticleDeleteCommandRequest, ArticleDeleteCommandResponse>
    {
        private readonly IArticleService _articleService;

        public ArticleDeleteCommandHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<ArticleDeleteCommandResponse> Handle(ArticleDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _articleService.ArticleDeleteAsync(request.Id);
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
