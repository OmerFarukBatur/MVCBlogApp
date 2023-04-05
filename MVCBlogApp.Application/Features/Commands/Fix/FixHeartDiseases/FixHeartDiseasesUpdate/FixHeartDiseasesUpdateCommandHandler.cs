using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Fix.FixHeartDiseases.FixHeartDiseasesUpdate
{
    public class FixHeartDiseasesUpdateCommandHandler : IRequestHandler<FixHeartDiseasesUpdateCommandRequest, FixHeartDiseasesUpdateCommandResponse>
    {
        private readonly IFixService _fixService;

        public FixHeartDiseasesUpdateCommandHandler(IFixService fixService)
        {
            _fixService = fixService;
        }

        public async Task<FixHeartDiseasesUpdateCommandResponse> Handle(FixHeartDiseasesUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            FixHeartDiseasesUpdateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _fixService.FixHeartDiseasesUpdateAsync(request);
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
