using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetFixBMICreateItems
{
    public class GetFixBMICreateItemsQueryHandler : IRequestHandler<GetFixBMICreateItemsQueryRequest, GetFixBMICreateItemsQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetFixBMICreateItemsQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetFixBMICreateItemsQueryResponse> Handle(GetFixBMICreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetFixBMICreateItemsAsync();
        }
    }
}
