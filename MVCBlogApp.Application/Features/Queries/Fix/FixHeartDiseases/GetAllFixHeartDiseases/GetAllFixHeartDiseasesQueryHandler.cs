using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixHeartDiseases.GetAllFixHeartDiseases
{
    public class GetAllFixHeartDiseasesQueryHandler : IRequestHandler<GetAllFixHeartDiseasesQueryRequest, GetAllFixHeartDiseasesQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetAllFixHeartDiseasesQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetAllFixHeartDiseasesQueryResponse> Handle(GetAllFixHeartDiseasesQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetAllFixHeartDiseasesAsync();
        }
    }
}
