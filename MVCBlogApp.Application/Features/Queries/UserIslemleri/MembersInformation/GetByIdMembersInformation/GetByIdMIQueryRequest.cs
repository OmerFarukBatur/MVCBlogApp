using MediatR;

namespace MVCBlogApp.Application.Features.Queries.UserIslemleri.MembersInformation.GetByIdMembersInformation
{
    public class GetByIdMIQueryRequest : IRequest<GetByIdMIQueryResponse>
    {
        public int Id { get; set; }
    }
}