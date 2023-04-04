using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMICreate
{
    public class FixBMICreateCommandHandler : IRequestHandler<FixBMICreateCommandRequest, FixBMICreateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixBMICreateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixBMICreateCommandResponse> Handle(FixBMICreateCommandRequest request, CancellationToken cancellationToken)
        {
            FixBMICreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixBMICreateAsync(request);
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
