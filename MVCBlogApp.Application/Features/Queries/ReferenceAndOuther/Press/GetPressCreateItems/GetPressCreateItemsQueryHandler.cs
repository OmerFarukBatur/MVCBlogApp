using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Press.GetPressCreateItems
{
    public class GetPressCreateItemsQueryHandler : IRequestHandler<GetPressCreateItemsQueryRequest, GetPressCreateItemsQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetPressCreateItemsQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetPressCreateItemsQueryResponse> Handle(GetPressCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _referenceService.GetPressCreateItemsAsync();
        }
    }
}
