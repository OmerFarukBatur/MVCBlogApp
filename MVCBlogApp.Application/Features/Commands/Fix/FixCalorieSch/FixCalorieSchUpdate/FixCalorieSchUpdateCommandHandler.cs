using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixCalorieSch.FixCalorieSchUpdate
{
    public class FixCalorieSchUpdateCommandHandler : IRequestHandler<FixCalorieSchUpdateCommandRequest, FixCalorieSchUpdateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixCalorieSchUpdateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixCalorieSchUpdateCommandResponse> Handle(FixCalorieSchUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            FixCalorieSchUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixCalorieSchUpdateAsync(request);
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
