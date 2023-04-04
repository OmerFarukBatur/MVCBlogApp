using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixBMI.FixBMIUpdate
{
    public class FixBMIUpdateCommandHandler : IRequestHandler<FixBMIUpdateCommandRequest, FixBMIUpdateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixBMIUpdateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixBMIUpdateCommandResponse> Handle(FixBMIUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            FixBMIUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixBMIUpdateAsync(request);
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
