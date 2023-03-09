using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetArticleCategoryCreateItems
{
    public class GetArticleCategoryCreateItemsQueryHandler : IRequestHandler<GetArticleCategoryCreateItemsQueryRequest, GetArticleCategoryCreateItemsQueryResponse>
    {
        private readonly IArticleService _articleService;

        public GetArticleCategoryCreateItemsQueryHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<GetArticleCategoryCreateItemsQueryResponse> Handle(GetArticleCategoryCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _articleService.GetArticleCategoryCreateItemsAsync();
        }
    }
}
