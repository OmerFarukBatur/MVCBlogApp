using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixOptimum.GetAllFixOptimum
{
    public class GetAllFixOptimumQueryHandler : IRequestHandler<GetAllFixOptimumQueryRequest, GetAllFixOptimumQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetAllFixOptimumQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetAllFixOptimumQueryResponse> Handle(GetAllFixOptimumQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetAllFixOptimumAsync();
        }
    }
}
