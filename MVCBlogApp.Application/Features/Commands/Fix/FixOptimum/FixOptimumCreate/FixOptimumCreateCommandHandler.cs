using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixOptimum.FixOptimumCreate
{
    public class FixOptimumCreateCommandHandler : IRequestHandler<FixOptimumCreateCommandRequest, FixOptimumCreateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixOptimumCreateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixOptimumCreateCommandResponse> Handle(FixOptimumCreateCommandRequest request, CancellationToken cancellationToken)
        {
            FixOptimumCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixOptimumCreateAsync(request);
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
