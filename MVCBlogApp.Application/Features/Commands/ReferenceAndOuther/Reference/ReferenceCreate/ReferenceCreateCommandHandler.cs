using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.ReferenceAndOuther.Reference.ReferenceCreate
{
    public class ReferenceCreateCommandHandler : IRequestHandler<ReferenceCreateCommandRequest, ReferenceCreateCommandResponse>
    {
        private readonly IReferenceService _referenceService;

        public ReferenceCreateCommandHandler(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public async Task<ReferenceCreateCommandResponse> Handle(ReferenceCreateCommandRequest request, CancellationToken cancellationToken)
        {
            ReferenceCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _referenceService.ReferenceCreateAsync(request);
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
