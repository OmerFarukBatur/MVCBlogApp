using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIArticle.UIArticleIndex
{
    public class UIArticleIndexQueryRequest : IRequest<UIArticleIndexQueryResponse>
    {
        public string id { get; set; }
    }
}