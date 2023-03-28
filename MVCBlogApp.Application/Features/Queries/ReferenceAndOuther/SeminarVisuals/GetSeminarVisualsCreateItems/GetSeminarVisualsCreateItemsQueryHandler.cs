using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.SeminarVisuals.GetSeminarVisualsCreateItems
{
    public class GetSeminarVisualsCreateItemsQueryHandler : IRequestHandler<GetSeminarVisualsCreateItemsQueryRequest, GetSeminarVisualsCreateItemsQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetSeminarVisualsCreateItemsQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetSeminarVisualsCreateItemsQueryResponse> Handle(GetSeminarVisualsCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _referenceService.GetSeminarVisualsCreateItemsAsync();
        }
    }
}
