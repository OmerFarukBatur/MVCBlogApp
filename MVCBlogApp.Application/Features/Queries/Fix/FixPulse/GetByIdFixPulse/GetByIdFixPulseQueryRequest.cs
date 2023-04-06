using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixPulse.GetByIdFixPulse
{
    public class GetByIdFixPulseQueryRequest : IRequest<GetByIdFixPulseQueryResponse>
    {
        public int Id { get; set; }
    }
}