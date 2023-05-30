using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Admin.Event.GetByIdEvent
{
    public class GetByIdEventQueryRequest : IRequest<GetByIdEventQueryResponse>
    {
        public int Id { get; set; }
    }
}