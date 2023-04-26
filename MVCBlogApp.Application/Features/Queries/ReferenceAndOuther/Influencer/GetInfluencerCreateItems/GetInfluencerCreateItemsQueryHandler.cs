using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Influencer.GetInfluencerCreateItems
{
    public class GetInfluencerCreateItemsQueryHandler : IRequestHandler<GetInfluencerCreateItemsQueryRequest, GetInfluencerCreateItemsQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetInfluencerCreateItemsQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetInfluencerCreateItemsQueryResponse> Handle(GetInfluencerCreateItemsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _referenceService.GetInfluencerCreateItemsAsync();
        }
    }
}
