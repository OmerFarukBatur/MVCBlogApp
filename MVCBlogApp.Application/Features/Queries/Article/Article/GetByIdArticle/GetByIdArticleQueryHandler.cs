using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Article.Article.GetByIdArticle
{
    public class GetByIdArticleQueryHandler : IRequestHandler<GetByIdArticleQueryRequest, GetByIdArticleQueryResponse>
    {
        private readonly IArticleService _articleService;

        public GetByIdArticleQueryHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<GetByIdArticleQueryResponse> Handle(GetByIdArticleQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _articleService.GetByIdArticleAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Article = null,
                    ArticleCategories = null,
                    Languages = null,
                    Navigations = null,
                    Statuses = null,
                    Message = "Lütfen geçerli değerler giriniz.",
                    State = false
                };
            }
        }
    }
}
