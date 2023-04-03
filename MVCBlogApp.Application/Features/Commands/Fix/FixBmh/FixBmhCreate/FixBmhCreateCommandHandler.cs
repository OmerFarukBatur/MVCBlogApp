using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixBmh.FixBmhCreate
{
    public class FixBmhCreateCommandHandler : IRequestHandler<FixBmhCreateCommandRequest, FixBmhCreateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixBmhCreateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixBmhCreateCommandResponse> Handle(FixBmhCreateCommandRequest request, CancellationToken cancellationToken)
        {
            FixBmhCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixBmhCreateAsync(request);
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
