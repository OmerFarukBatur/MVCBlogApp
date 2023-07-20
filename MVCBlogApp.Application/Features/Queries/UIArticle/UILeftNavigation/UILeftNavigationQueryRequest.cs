using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIArticle.UILeftNavigation
{
    public class UILeftNavigationQueryRequest : IRequest<UILeftNavigationQueryResponse>
    {
        public string orderNo { get; set; }
        public int? parentID { get; set; }
    }
}