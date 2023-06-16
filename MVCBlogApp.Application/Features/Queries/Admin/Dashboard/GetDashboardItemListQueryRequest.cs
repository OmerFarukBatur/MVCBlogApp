using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Admin.Dashboard
{
    public class GetDashboardItemListQueryRequest : IRequest<GetDashboardItemListQueryResponse>
    {
    }
}