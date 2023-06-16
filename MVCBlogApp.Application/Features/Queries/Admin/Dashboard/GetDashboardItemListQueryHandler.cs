using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Admin.Dashboard
{
    public class GetDashboardItemListQueryHandler : IRequestHandler<GetDashboardItemListQueryRequest, GetDashboardItemListQueryResponse>
    {
        private readonly IAdminGeneralProcess _process;

        public GetDashboardItemListQueryHandler(IAdminGeneralProcess process)
        {
            _process = process;
        }

        public async Task<GetDashboardItemListQueryResponse> Handle(GetDashboardItemListQueryRequest request, CancellationToken cancellationToken)
        {
            return await _process.GetDashboardItemListAsync();
        }
    }
}
