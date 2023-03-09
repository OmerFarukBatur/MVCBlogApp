using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Article.ArticleCategory.GetByIdArticleCategory
{
    public class GetByIdArticleCategoryQueryRequest : IRequest<GetByIdArticleCategoryQueryResponse>
    {
        public int Id { get; set; }
    }
}