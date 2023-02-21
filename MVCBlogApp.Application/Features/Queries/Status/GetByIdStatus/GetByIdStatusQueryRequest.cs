using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Status.GetByIdStatus
{
    public class GetByIdStatusQueryRequest : IRequest<GetByIdStatusQueryResponse>
    {
        public int Id { get; set; }
    }
}