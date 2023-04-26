using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Queries.ReferenceAndOuther.Influencer.GetByIdInfluencer
{
    public class GetByIdInfluencerQueryHandler : IRequestHandler<GetByIdInfluencerQueryRequest, GetByIdInfluencerQueryResponse>
    {
        private readonly IReferenceService _referenceService;

        public GetByIdInfluencerQueryHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<GetByIdInfluencerQueryResponse> Handle(GetByIdInfluencerQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _referenceService.GetByIdInfluencerAsync(request.Id);
            }
            else
            {
                return new()
                {
                    Statuses = null,
                    Influencer = null,
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
