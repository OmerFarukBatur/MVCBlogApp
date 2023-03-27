using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceUpdate
{
    public class ReferenceUpdateCommandHandler : IRequestHandler<ReferenceUpdateCommandRequest, ReferenceUpdateCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public ReferenceUpdateCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<ReferenceUpdateCommandResponse> Handle(ReferenceUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            ReferenceUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _referenceService.ReferenceUpdateAsync(request);
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
