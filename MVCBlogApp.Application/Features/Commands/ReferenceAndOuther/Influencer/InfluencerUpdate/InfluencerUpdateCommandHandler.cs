using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerUpdate
{
    public class InfluencerUpdateCommandHandler : IRequestHandler<InfluencerUpdateCommandRequest, InfluencerUpdateCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public InfluencerUpdateCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<InfluencerUpdateCommandResponse> Handle(InfluencerUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            InfluencerUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _referenceService.InfluencerUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlerle doldurunuz.",
                    State = false
                };
            }
        }
    }
}
