using FluentValidation.Results;
using MediatR;
using MVCBlogApp.Application.Abstractions.Services;

namespace MVCBlogApp.Application.Features.Commands.Test.OptimumCalculateCreate
{
    public class OptimumCalculateCreateCommandHandler : IRequestHandler<OptimumCalculateCreateCommandRequest, OptimumCalculateCreateCommandResponse>
    {
        private readonly IUIOtherService _service;

        public OptimumCalculateCreateCommandHandler(IUIOtherService service)
        {
            _service = service;
        }

        public async Task<OptimumCalculateCreateCommandResponse> Handle(OptimumCalculateCreateCommandRequest request, CancellationToken cancellationToken)
        {
            OptimumCalculateCreateCommandValidator rules = new();
            ValidationResult validation = rules.Validate(request);

            if (validation.IsValid)
            {
                return await _service.OptimumCalculateCreateAsync(request);
            }
            else
            {
                return new()
                {
                    Optimum = null
                };
            }
        }
    }
}
