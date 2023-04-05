using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeCreate
{
    public class FixMealSizeCreateCommandHandler : IRequestHandler<FixMealSizeCreateCommandRequest, FixMealSizeCreateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixMealSizeCreateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixMealSizeCreateCommandResponse> Handle(FixMealSizeCreateCommandRequest request, CancellationToken cancellationToken)
        {
            FixMealSizeCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixMealSizeCreateAsync(request);
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
