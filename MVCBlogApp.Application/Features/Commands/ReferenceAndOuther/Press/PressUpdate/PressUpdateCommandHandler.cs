using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Press.PressUpdate
{
    public class PressUpdateCommandHandler : IRequestHandler<PressUpdateCommandRequest, PressUpdateCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public PressUpdateCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<PressUpdateCommandResponse> Handle(PressUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            PressUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _referenceService.PressUpdateAsync(request);
            }
            else
            {
                return new()
                {
                    Message = "Lütfen alanları geçerli değerlele doldurunuz.",
                    State = false
                };
            }
        }
    }
}
