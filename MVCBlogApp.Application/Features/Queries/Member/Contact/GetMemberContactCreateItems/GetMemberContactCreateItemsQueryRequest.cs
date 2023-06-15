using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Member.Contact.GetMemberContactCreateItems
{
    public class GetMemberContactCreateItemsQueryRequest : IRequest<GetMemberContactCreateItemsQueryResponse>
    {
        public int MemberId { get; set; }
    }
}