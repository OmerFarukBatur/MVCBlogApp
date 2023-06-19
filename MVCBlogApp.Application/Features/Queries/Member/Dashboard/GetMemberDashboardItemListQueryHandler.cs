using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Member.Dashboard
{
    public class GetMemberDashboardItemListQueryHandler : IRequestHandler<GetMemberDashboardItemListQueryRequest, GetMemberDashboardItemListQueryResponse>
    {
        private readonly IMemberGeneralProcess _process;

        public GetMemberDashboardItemListQueryHandler(IMemberGeneralProcess process)
        {
            _process = process;
        }

        public async Task<GetMemberDashboardItemListQueryResponse> Handle(GetMemberDashboardItemListQueryRequest request, CancellationToken cancellationToken)
        {
            return await _process.GetMemberDashboardItemListAsync(request.Id);
        }
    }
}
