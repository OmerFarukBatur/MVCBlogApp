using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixPulse.FixPulseUpdate
{
    public class FixPulseUpdateCommandHandler : IRequestHandler<FixPulseUpdateCommandRequest, FixPulseUpdateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixPulseUpdateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixPulseUpdateCommandResponse> Handle(FixPulseUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            FixPulseUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixPulseUpdateAsync(request);
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
