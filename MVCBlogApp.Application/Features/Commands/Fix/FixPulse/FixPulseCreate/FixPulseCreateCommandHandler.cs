using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixPulse.FixPulseCreate
{
    public class FixPulseCreateCommandHandler : IRequestHandler<FixPulseCreateCommandRequest, FixPulseCreateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixPulseCreateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixPulseCreateCommandResponse> Handle(FixPulseCreateCommandRequest request, CancellationToken cancellationToken)
        {
            FixPulseCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixPulseCreateAsync(request);
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
