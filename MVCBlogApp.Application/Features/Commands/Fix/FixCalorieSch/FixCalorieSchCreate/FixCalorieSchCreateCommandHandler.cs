using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchCreate
{
    public class FixCalorieSchCreateCommandHandler : IRequestHandler<FixCalorieSchCreateCommandRequest, FixCalorieSchCreateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixCalorieSchCreateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixCalorieSchCreateCommandResponse> Handle(FixCalorieSchCreateCommandRequest request, CancellationToken cancellationToken)
        {
            FixCalorieSchCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixCalorieSchCreateAsync(request);
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
