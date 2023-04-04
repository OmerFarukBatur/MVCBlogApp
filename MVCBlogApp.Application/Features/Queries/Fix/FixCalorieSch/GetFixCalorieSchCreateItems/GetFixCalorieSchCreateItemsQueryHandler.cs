using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetFixCalorieSchCreateItems
{
    public class GetFixCalorieSchCreateItemsQueryHandler : IRequestHandler<GetFixCalorieSchCreateItemsQueryRequest, GetFixCalorieSchCreateItemsQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetFixCalorieSchCreateItemsQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetFixCalorieSchCreateItemsQueryResponse> Handle(GetFixCalorieSchCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetFixCalorieSchCreateItemsAsync();
        }
    }
}
