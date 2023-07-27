using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Test.OptimumCalculate
{
    public class OptimumCalculateQueryHandler : IRequestHandler<OptimumCalculateQueryRequest, OptimumCalculateQueryResponse>
    {
        private readonly IUIOtherService _service;

        public OptimumCalculateQueryHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<OptimumCalculateQueryResponse> Handle(OptimumCalculateQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.OptimumCalculateAsync();
        }
    }
}
