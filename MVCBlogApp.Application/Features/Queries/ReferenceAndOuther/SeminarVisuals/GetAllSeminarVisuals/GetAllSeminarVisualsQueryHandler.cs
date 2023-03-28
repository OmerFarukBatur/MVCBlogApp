using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetAllSeminarVisuals
{
    public class GetAllSeminarVisualsQueryHandler : IRequestHandler<GetAllSeminarVisualsQueryRequest, GetAllSeminarVisualsQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetAllSeminarVisualsQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetAllSeminarVisualsQueryResponse> Handle(GetAllSeminarVisualsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _referenceService.GetAllSeminarVisualsAsync();
        }
    }
}
