using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixFeedPyramid.GetAllFixFeedPyramid
{
    public class GetAllFixFeedPyramidQueryHandler : IRequestHandler<GetAllFixFeedPyramidQueryRequest, GetAllFixFeedPyramidQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetAllFixFeedPyramidQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetAllFixFeedPyramidQueryResponse> Handle(GetAllFixFeedPyramidQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetAllFixFeedPyramidAsync();
        }
    }
}
