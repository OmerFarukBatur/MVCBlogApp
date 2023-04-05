using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetFixHeartDiseasesCreateItems
{
    public class GetFixHeartDiseasesCreateItemsQueryHandler : IRequestHandler<GetFixHeartDiseasesCreateItemsQueryRequest, GetFixHeartDiseasesCreateItemsQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetFixHeartDiseasesCreateItemsQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetFixHeartDiseasesCreateItemsQueryResponse> Handle(GetFixHeartDiseasesCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetFixHeartDiseasesCreateItemsAsync();
        }
    }
}
