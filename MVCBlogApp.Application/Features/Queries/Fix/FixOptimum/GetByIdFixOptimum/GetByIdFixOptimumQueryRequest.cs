using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixOptimum.GetByIdFixOptimum
{
    public class GetByIdFixOptimumQueryRequest : IRequest<GetByIdFixOptimumQueryResponse>
    {
        public int Id { get; set; }
    }
}