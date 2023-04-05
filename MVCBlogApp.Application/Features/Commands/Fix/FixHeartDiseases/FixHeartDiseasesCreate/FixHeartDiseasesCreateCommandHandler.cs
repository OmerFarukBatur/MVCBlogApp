using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesCreate
{
    public class FixHeartDiseasesCreateCommandHandler : IRequestHandler<FixHeartDiseasesCreateCommandRequest, FixHeartDiseasesCreateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixHeartDiseasesCreateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixHeartDiseasesCreateCommandResponse> Handle(FixHeartDiseasesCreateCommandRequest request, CancellationToken cancellationToken)
        {
            FixHeartDiseasesCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixHeartDiseasesCreateAsync(request);
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
