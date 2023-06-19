using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Member.Header
{
    public class GetByUserImageQueryRequest : IRequest<GetByUserImageQueryResponse>
    {
        public int Id { get; set; }
    }
}