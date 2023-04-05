using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixMealSize.FixMealSizeUpdate
{
    public class FixMealSizeUpdateCommandHandler : IRequestHandler<FixMealSizeUpdateCommandRequest, FixMealSizeUpdateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixMealSizeUpdateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixMealSizeUpdateCommandResponse> Handle(FixMealSizeUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            FixMealSizeUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixMealSizeUpdateAsync(request);
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
