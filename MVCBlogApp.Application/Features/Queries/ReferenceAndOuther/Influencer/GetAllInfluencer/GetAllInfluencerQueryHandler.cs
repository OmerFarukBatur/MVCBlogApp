using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Influencer.GetAllInfluencer
{
    public class GetAllInfluencerQueryHandler : IRequestHandler<GetAllInfluencerQueryRequest, GetAllInfluencerQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetAllInfluencerQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetAllInfluencerQueryResponse> Handle(GetAllInfluencerQueryRequest request, CancellationToken cancellationToken)
        {
            return await _referenceService.GetAllInfluencerAsync();
        }
    }
}
