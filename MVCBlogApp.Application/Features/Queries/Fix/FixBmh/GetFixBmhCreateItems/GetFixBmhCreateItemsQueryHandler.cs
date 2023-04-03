using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetFixBmhCreateItems
{
    public class GetFixBmhCreateItemsQueryHandler : IRequestHandler<GetFixBmhCreateItemsQueryRequest, GetFixBmhCreateItemsQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetFixBmhCreateItemsQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetFixBmhCreateItemsQueryResponse> Handle(GetFixBmhCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetFixBmhCreateItemsAsync();
        }
    }
}
