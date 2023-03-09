using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetByIdArticleCategory
{
    public class GetByIdArticleCategoryQueryHandler : IRequestHandler<GetByIdArticleCategoryQueryRequest, GetByIdArticleCategoryQueryResponse>
    {
        private readonly IArticleService _articleService;

        public GetByIdArticleCategoryQueryHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<GetByIdArticleCategoryQueryResponse> Handle(GetByIdArticleCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _articleService.GetByIdArticleCategoryAsync(request.Id);
            }
            else
            {
                return new()
                {
                    ArticleCategories = null,
                    ArticleCategory = null,
                    Languages = null,
                    Statuses = null,
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
