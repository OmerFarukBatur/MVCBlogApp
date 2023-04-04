using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixCalorieSch.GetAllFixCalorieSch
{
    public class GetAllFixCalorieSchQueryHandler : IRequestHandler<GetAllFixCalorieSchQueryRequest, GetAllFixCalorieSchQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetAllFixCalorieSchQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetAllFixCalorieSchQueryResponse> Handle(GetAllFixCalorieSchQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetAllFixCalorieSchAsync();
        }
    }
}
