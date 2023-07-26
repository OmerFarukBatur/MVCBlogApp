using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Test.BMICalculateCreate
{
    public class BMICalculateCreateCommandHandler : IRequestHandler<BMICalculateCreateCommandRequest, BMICalculateCreateCommandResponse>
    {
        private readonly IUIOtherService _uIOtherService;

        public BMICalculateCreateCommandHandler(IUIOtherService uIOtherService)
        {
            _uIOtherService = uIOtherService;
        }

        public async Task<BMICalculateCreateCommandResponse> Handle(BMICalculateCreateCommandRequest request, CancellationToken cancellationToken)
        {
            BMICalculateCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _uIOtherService.BMICalculateCreateAsync(request);
            }
            else
            {
                return new()
                {
                    BMI = null
                };
            }
        }
    }
}
