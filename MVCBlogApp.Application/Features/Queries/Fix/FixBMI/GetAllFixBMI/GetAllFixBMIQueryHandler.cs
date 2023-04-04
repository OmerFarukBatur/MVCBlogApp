using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.Fix.FixBMI.GetAllFixBMI
{
    public class GetAllFixBMIQueryHandler : IRequestHandler<GetAllFixBMIQueryRequest, GetAllFixBMIQueryResponse>
    {
        private readonly IFixService _fixService;

        public GetAllFixBMIQueryHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<GetAllFixBMIQueryResponse> Handle(GetAllFixBMIQueryRequest request, CancellationToken cancellationToken)
        {
            return await _fixService.GetAllFixBMIAsync();
        }
    }
}
