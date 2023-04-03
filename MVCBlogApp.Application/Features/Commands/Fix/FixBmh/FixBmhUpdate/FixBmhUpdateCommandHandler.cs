using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhUpdate
{
    public class FixBmhUpdateCommandHandler : IRequestHandler<FixBmhUpdateCommandRequest, FixBmhUpdateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixBmhUpdateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixBmhUpdateCommandResponse> Handle(FixBmhUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            FixBmhUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixBmhUpdateAsync(request);
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
