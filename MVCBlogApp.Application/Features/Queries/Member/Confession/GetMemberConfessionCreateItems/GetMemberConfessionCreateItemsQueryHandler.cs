using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Member.Confession.GetMemberConfessionCreateItems
{
    public class GetMemberConfessionCreateItemsQueryHandler : IRequestHandler<GetMemberConfessionCreateItemsQueryRequest, GetMemberConfessionCreateItemsQueryResponse>
    {
        private readonly IMemberGeneralProcess _memberGeneralProcess;

        public GetMemberConfessionCreateItemsQueryHandler(IMemberGeneralProcess memberGeneralProcess)
        {
            _memberGeneralProcess = memberGeneralProcess;
        }

        public async Task<GetMemberConfessionCreateItemsQueryResponse> Handle(GetMemberConfessionCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _memberGeneralProcess.GetMemberConfessionCreateItemsAsync(request.MemberId);
        }
    }
}
