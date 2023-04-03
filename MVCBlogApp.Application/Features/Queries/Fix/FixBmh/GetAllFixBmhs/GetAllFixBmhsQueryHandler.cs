using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixBmh.GetAllFixBmhs
{
    public class GetAllFixBmhsQueryHandler : IRequestHandler<GetAllFixBmhsQueryRequest, GetAllFixBmhsQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetAllFixBmhsQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetAllFixBmhsQueryResponse> Handle(GetAllFixBmhsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetAllFixBmhsAsync();
        }
    }
}
