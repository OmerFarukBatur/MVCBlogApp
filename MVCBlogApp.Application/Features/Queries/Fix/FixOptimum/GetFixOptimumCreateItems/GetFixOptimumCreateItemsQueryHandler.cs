using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixOptimum.GetFixOptimumCreateItems
{
    public class GetFixOptimumCreateItemsQueryHandler : IRequestHandler<GetFixOptimumCreateItemsQueryRequest, GetFixOptimumCreateItemsQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetFixOptimumCreateItemsQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetFixOptimumCreateItemsQueryResponse> Handle(GetFixOptimumCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetFixOptimumCreateItemsAsync();
        }
    }
}
