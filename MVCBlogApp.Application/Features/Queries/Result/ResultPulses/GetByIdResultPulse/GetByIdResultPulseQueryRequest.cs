using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultPulses.GetByIdResultPulse
{
    public class GetByIdResultPulseQueryRequest : IRequest<GetByIdResultPulseQueryResponse>
    {
        public int Id { get; set; }
    }
}