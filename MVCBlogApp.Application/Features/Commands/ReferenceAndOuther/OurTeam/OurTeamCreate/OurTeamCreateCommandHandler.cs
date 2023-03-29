using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamCreate
{
    public class OurTeamCreateCommandHandler : IRequestHandler<OurTeamCreateCommandRequest, OurTeamCreateCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public OurTeamCreateCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<OurTeamCreateCommandResponse> Handle(OurTeamCreateCommandRequest request, CancellationToken cancellationToken)
        {
            OurTeamCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _referenceService.OurTeamCreateAsync(request);
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
