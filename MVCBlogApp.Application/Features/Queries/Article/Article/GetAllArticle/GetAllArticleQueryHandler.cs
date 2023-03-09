using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Article.Article.GetAllArticle
{
    public class GetAllArticleQueryHandler : IRequestHandler<GetAllArticleQueryRequest, GetAllArticleQueryResponse>
    {
        private readonly IArticleService _articleService;

        public GetAllArticleQueryHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<GetAllArticleQueryResponse> Handle(GetAllArticleQueryRequest request, CancellationToken cancellationToken)
        {
            return await _articleService.GetAllArticleAsync();
        }
    }
}
