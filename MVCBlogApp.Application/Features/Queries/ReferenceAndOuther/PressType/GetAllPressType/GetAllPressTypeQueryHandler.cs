using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.PressType.GetAllPressType
{
    public class GetAllPressTypeQueryHandler : IRequestHandler<GetAllPressTypeQueryRequest, GetAllPressTypeQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetAllPressTypeQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetAllPressTypeQueryResponse> Handle(GetAllPressTypeQueryRequest request, CancellationToken cancellationToken)
        {
            return await _referenceService.GetAllPressTypeAsync();
        }
    }
}
