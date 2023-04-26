using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerDelete
{
    public class InfluencerDeleteCommandHandler : IRequestHandler<InfluencerDeleteCommandRequest, InfluencerDeleteCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public InfluencerDeleteCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<InfluencerDeleteCommandResponse> Handle(InfluencerDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                return await _referenceService.InfluencerDeleteAsync(request.Id);
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Kayıt bulunamamıştır."
                };
            }
        }
    }
}
