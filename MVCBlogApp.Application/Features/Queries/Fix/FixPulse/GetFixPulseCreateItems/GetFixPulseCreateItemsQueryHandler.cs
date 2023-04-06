using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixPulse.GetFixPulseCreateItems
{
    public class GetFixPulseCreateItemsQueryHandler : IRequestHandler<GetFixPulseCreateItemsQueryRequest, GetFixPulseCreateItemsQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetFixPulseCreateItemsQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetFixPulseCreateItemsQueryResponse> Handle(GetFixPulseCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetFixPulseCreateItemsAsync();
        }
    }
}
