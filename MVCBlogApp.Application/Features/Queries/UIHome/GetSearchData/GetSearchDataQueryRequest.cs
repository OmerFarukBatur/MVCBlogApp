using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UIHome.GetSearchData
{
    public class GetSearchDataQueryRequest : IRequest<GetSearchDataQueryResponse>
    {
        public string QueryKeyword { get; set; }
    }
}