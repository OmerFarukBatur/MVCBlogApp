using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Press.PressCreate
{
    public class PressCreateCommandHandler : IRequestHandler<PressCreateCommandRequest, PressCreateCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public PressCreateCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<PressCreateCommandResponse> Handle(PressCreateCommandRequest request, CancellationToken cancellationToken)
        {
            PressCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _referenceService.PressCreateAsync(request);
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
