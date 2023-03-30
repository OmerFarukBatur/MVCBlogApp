using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetAllPress
{
    public class GetAllPressQueryHandler : IRequestHandler<GetAllPressQueryRequest, GetAllPressQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetAllPressQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetAllPressQueryResponse> Handle(GetAllPressQueryRequest request, CancellationToken cancellationToken)
        {
            return await _referenceService.GetAllPressAsync();
        }
    }
}
