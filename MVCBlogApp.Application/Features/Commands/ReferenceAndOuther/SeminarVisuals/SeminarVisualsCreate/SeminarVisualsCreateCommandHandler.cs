using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsCreate
{
    public class SeminarVisualsCreateCommandHandler : IRequestHandler<SeminarVisualsCreateCommandRequest, SeminarVisualsCreateCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public SeminarVisualsCreateCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<SeminarVisualsCreateCommandResponse> Handle(SeminarVisualsCreateCommandRequest request, CancellationToken cancellationToken)
        {
            SeminarVisualsCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _referenceService.SeminarVisualsCreateAsync(request);
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
