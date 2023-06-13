using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Member.MemberInfo.GetByIdMemberInfo
{
    public class GetByIdMemberInfoQueryRequest : IRequest<GetByIdMemberInfoQueryResponse>
    {
        public int Id { get; set; }
    }
}