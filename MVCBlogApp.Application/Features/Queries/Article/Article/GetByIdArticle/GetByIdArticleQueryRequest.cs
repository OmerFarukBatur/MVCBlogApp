using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Article.Article.GetByIdArticle
{
    public class GetByIdArticleQueryRequest : IRequest<GetByIdArticleQueryResponse>
    {
        public int Id { get; set; }
    }
}