using MediatR;

namespace MVCBlogApp.Application.Features.Queries.Result.ResultOptimums.GetByIdResultOptimum
{
    public class GetByIdResultOptimumQueryRequest : IRequest<GetByIdResultOptimumQueryResponse>
    {
        public int Id { get; set; }
    }
}