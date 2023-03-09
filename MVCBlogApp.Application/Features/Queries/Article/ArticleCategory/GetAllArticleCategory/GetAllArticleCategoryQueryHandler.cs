using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetAllArticleCategory
{
    public class GetAllArticleCategoryQueryHandler : IRequestHandler<GetAllArticleCategoryQueryRequest, GetAllArticleCategoryQueryResponse>
    {
        private readonly IArticleService _articleService;

        public GetAllArticleCategoryQueryHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<GetAllArticleCategoryQueryResponse> Handle(GetAllArticleCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            return await _articleService.GetAllArticleCategoryAsync();
        }
    }
}
