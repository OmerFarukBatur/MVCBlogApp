using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Reference.GetReferenceCreateItems
{
    public class GetReferenceCreateItemsQueryHandler : IRequestHandler<GetReferenceCreateItemsQueryRequest, GetReferenceCreateItemsQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetReferenceCreateItemsQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetReferenceCreateItemsQueryResponse> Handle(GetReferenceCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _referenceService.GetReferenceCreateItemsAsync();
        }
    }
}
