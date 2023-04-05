using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixMealSize.GetAllFixMealSize
{
    public class GetAllFixMealSizeQueryHandler : IRequestHandler<GetAllFixMealSizeQueryRequest, GetAllFixMealSizeQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetAllFixMealSizeQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetAllFixMealSizeQueryResponse> Handle(GetAllFixMealSizeQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetAllFixMealSizeAsync();
        }
    }
}
