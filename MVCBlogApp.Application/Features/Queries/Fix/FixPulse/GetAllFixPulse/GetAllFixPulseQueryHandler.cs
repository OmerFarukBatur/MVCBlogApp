using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixPulse.GetAllFixPulse
{
    public class GetAllFixPulseQueryHandler : IRequestHandler<GetAllFixPulseQueryRequest, GetAllFixPulseQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetAllFixPulseQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetAllFixPulseQueryResponse> Handle(GetAllFixPulseQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetAllFixPulseAsync();
        }
    }
}
