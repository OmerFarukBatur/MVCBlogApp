using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Member.Dashboard
{
    public class GetMemberDashboardItemListQueryRequest : IRequest<GetMemberDashboardItemListQueryResponse>
    {
        public int Id { get; set; }
    }
}