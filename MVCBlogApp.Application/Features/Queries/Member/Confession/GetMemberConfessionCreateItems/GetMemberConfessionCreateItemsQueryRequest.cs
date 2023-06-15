using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Member.Confession.GetMemberConfessionCreateItems
{
    public class GetMemberConfessionCreateItemsQueryRequest : IRequest<GetMemberConfessionCreateItemsQueryResponse>
    {
        public int MemberId { get; set; }
    }
}