using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.SeminarVisuals.SeminarVisualsUpdate
{
    public class SeminarVisualsUpdateCommandHandler : IRequestHandler<SeminarVisualsUpdateCommandRequest, SeminarVisualsUpdateCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public SeminarVisualsUpdateCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<SeminarVisualsUpdateCommandResponse> Handle(SeminarVisualsUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            SeminarVisualsUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _referenceService.SeminarVisualsUpdateAsync(request);
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
