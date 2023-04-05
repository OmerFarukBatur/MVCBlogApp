using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetFixMealSizeCreateItems
{
    public class GetFixMealSizeCreateItemsQueryHandler : IRequestHandler<GetFixMealSizeCreateItemsQueryRequest, GetFixMealSizeCreateItemsQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetFixMealSizeCreateItemsQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetFixMealSizeCreateItemsQueryResponse> Handle(GetFixMealSizeCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetFixMealSizeCreateItemsAsync();
        }
    }
}
