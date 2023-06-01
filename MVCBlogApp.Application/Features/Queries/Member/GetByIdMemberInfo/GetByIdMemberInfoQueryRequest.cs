using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Member.GetByIdMemberInfo
{
    public class GetByIdMemberInfoQueryRequest : IRequest<GetByIdMemberInfoQueryResponse>
    {
        public int Id { get; set; }
    }
}