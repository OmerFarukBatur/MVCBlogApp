using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Member.Contact.GetMemberContactCreateItems
{
    public class GetMemberContactCreateItemsQueryHandler : IRequestHandler<GetMemberContactCreateItemsQueryRequest, GetMemberContactCreateItemsQueryResponse>
    {
        private readonly IMemberGeneralProcess _process;

        public GetMemberContactCreateItemsQueryHandler(IMemberGeneralProcess process)
        {
            _process = process;
        }

        public async Task<GetMemberContactCreateItemsQueryResponse> Handle(GetMemberContactCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _process.GetMemberContactCreateItemsAsync(request.MemberId);
        }
    }
}
