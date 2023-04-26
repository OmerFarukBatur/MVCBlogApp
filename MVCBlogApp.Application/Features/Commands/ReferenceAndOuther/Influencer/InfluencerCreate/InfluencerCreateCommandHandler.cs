using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Influencer.InfluencerCreate
{
    public class InfluencerCreateCommandHandler : IRequestHandler<InfluencerCreateCommandRequest, InfluencerCreateCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public InfluencerCreateCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<InfluencerCreateCommandResponse> Handle(InfluencerCreateCommandRequest request, CancellationToken cancellationToken)
        {
            InfluencerCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _referenceService.InfluencerCreateAsync(request);
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
