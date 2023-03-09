using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Article.Article.GetArticleCreateItems
{
    public class GetArticleCreateItemsQueryHandler : IRequestHandler<GetArticleCreateItemsQueryRequest, GetArticleCreateItemsQueryResponse>
    {
        private readonly IArticleService _articleService;

        public GetArticleCreateItemsQueryHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<GetArticleCreateItemsQueryResponse> Handle(GetArticleCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _articleService.GetArticleCreateItemsAsync();
        }
    }
}
