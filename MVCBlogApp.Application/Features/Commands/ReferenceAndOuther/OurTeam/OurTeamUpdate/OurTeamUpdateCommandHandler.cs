using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.OurTeam.OurTeamUpdate
{
    public class OurTeamUpdateCommandHandler : IRequestHandler<OurTeamUpdateCommandRequest, OurTeamUpdateCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public OurTeamUpdateCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<OurTeamUpdateCommandResponse> Handle(OurTeamUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            OurTeamUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);
            if (validation.IsValid)
            {
                return await _referenceService.OurTeamUpdateAsync(request);
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
