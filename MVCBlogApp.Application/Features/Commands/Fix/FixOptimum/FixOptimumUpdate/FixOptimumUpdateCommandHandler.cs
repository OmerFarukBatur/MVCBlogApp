using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixOptimum.FixOptimumUpdate
{
    public class FixOptimumUpdateCommandHandler : IRequestHandler<FixOptimumUpdateCommandRequest, FixOptimumUpdateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixOptimumUpdateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixOptimumUpdateCommandResponse> Handle(FixOptimumUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            FixOptimumUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixOptimumUpdateAsync(request);
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
